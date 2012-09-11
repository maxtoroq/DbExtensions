using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Reflection;
using DbExtensions;

namespace Samples {

   class Program {

      static void Main() {
         new Program().Run();
      }

      void Run() {

         Console.WriteLine("DbExtensions Sample Runner");
         Console.WriteLine("==========================");

         var connectionStrings = ConfigurationManager.ConnectionStrings
            .Cast<ConnectionStringSettings>()
            // Only connection strings defined in this application config file (not in machine.config)
            .Where(c => c.ElementInformation.Source != null && c.ElementInformation.Source.EndsWith("exe.config", StringComparison.OrdinalIgnoreCase))
            .ToArray();

         int connIndex = GetArrayOption(connectionStrings.Select(c => c.Name).ToArray(), "Select a connection string (or Enter to select the first one):");
         var connSettings = connectionStrings[connIndex];
         var provider = DbFactory.GetProviderFactory(connSettings.ProviderName);
         var connString = "name=" + connSettings.Name;

         Console.WriteLine();
         Console.WriteLine("Provider: {0}", provider.GetType().AssemblyQualifiedName);
         Console.WriteLine();
         Console.WriteLine("Connecting...");

         try {
            var conn = DbFactory.CreateConnection(connString);
            using (conn.EnsureOpen())
               Console.WriteLine("Server Version: {0}", conn.ServerVersion);
         } catch (Exception ex) {

            WriteError(ex, fatal: true);
            return;
         }

         string[] samplesLangs = { "C#", "VB" };
         int samplesLangIndex = GetArrayOption(samplesLangs, "Select the samples language (or Enter):");
         string samplesLanguage = samplesLangs[samplesLangIndex];
         
         MappingSource[] mappingSources = { new AttributeMappingSource(), XmlMappingSource.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Samples.Northwind.Northwind.xml")) };
         int mappingSourceIndex = GetArrayOption(mappingSources, "Select the mapping source (or Enter):");
         MappingSource mappingSource = mappingSources[mappingSourceIndex];
         
         object[] samples = GetSamples(samplesLanguage, connString, mappingSource, Console.Out).ToArray();
         string[] samplesOptions = samples.Select(o => o.GetType().Name).Concat(new[] { "All" }).ToArray();

         int samplesIndex = GetArrayOption(samplesOptions, "Select the samples category (or Enter to run all):", samplesOptions.Length - 1);

         object[] selectedSamples = (samplesIndex == samplesOptions.Length - 1) ?
            samples
            : new[] { samples[samplesIndex] };

         string[] continueOnErrorOptions = { "Yes", "No" };
         bool continueOnError = GetArrayOption(continueOnErrorOptions, "Continue on Error:") == 0;

         Console.WriteLine();
         Console.WriteLine("Press key to begin...");
         Console.ReadKey();

         for (int i = 0; i < selectedSamples.Length; i++) {

            RunSamples(selectedSamples[i], continueOnError);
            Console.WriteLine();
            Console.WriteLine((i == selectedSamples.Length - 1) ? "Press key to continue..." : "Press key to exit...");
            Console.ReadKey();
         }
      }

      IEnumerable<object> GetSamples(string language, string connString, MappingSource mappingSource, TextWriter log) {

         MetaModel mapping;

         switch (language) {
            case "C#":
               mapping = (mappingSource is AttributeMappingSource) ? 
                  mappingSource.GetModel(typeof(Samples.CSharp.Northwind.NorthwindDatabase)) 
                  : mappingSource.GetModel(typeof(Samples.CSharp.Northwind.ForXmlMappingSourceOnlyDataContext));

               yield return new Samples.CSharp.ExtensionMethodsSamples(connString, log);
               yield return new Samples.CSharp.SqlBuilderSamples();
               yield return new Samples.CSharp.SqlSetSamples(connString, log);
               yield return new Samples.CSharp.DatabaseSamples(connString, mapping, log);
               break;

            case "VB":
               mapping = (mappingSource is AttributeMappingSource) ? 
                  mappingSource.GetModel(typeof(Samples.VisualBasic.Northwind.NorthwindDatabase)) 
                  : mappingSource.GetModel(typeof(Samples.VisualBasic.Northwind.ForXmlMappingSourceOnlyDataContext));

               yield return new Samples.VisualBasic.ExtensionMethodsSamples(connString, log);
               yield return new Samples.VisualBasic.SqlBuilderSamples();
               yield return new Samples.VisualBasic.SqlSetSamples(connString, log);
               yield return new Samples.VisualBasic.DatabaseSamples(connString, mapping, log);
               break;

            default:
               throw new ArgumentOutOfRangeException("language", "Only C# and VB are accepted.");
         }
      }

      void RunSamples(object samples, bool continueOnError) {

         Type samplesType = samples.GetType();
         List<MethodInfo> methods = new List<MethodInfo>();
         methods.AddRange(samplesType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly));

         for (int i = 0; i < methods.Count; i++) {
            MethodInfo method = methods[i];

            Console.WriteLine();
            Console.WriteLine(method.Name);
            Array.ForEach<char>(method.Name.ToCharArray(), c => Console.Write("="));
            Console.WriteLine();

            object returnValue = null;

            if (method.ReturnType == typeof(void)) {

               var sample = (Action)Delegate.CreateDelegate(typeof(Action), samples, method);

               if (continueOnError) {

                  try {
                     sample();
                  } catch (Exception ex) {
                     WriteError(ex);
                  }

               } else {
                  sample();
               }
               
            } else {

               var sample = (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), samples, method);

               if (continueOnError) {

                  try {
                     returnValue = sample();
                  } catch (Exception ex) {
                     WriteError(ex);
                  }

               } else {
                  returnValue = sample();
               }
            }

            if (returnValue != null) {

               Console.WriteLine();

               SqlBuilder sqlbuilder = returnValue as SqlBuilder;

               if (sqlbuilder != null) {
                  
                  Console.WriteLine(returnValue);
                  
                  for (int j = 0; j < sqlbuilder.ParameterValues.Count; j++) {

                     object value = sqlbuilder.ParameterValues[j];
                     Type type = (value != null) ? value.GetType() : null;

                     Console.WriteLine("-- {0}: {1} [{2}]", j, type, value);
                  }

               } else {

                  if (returnValue is IEnumerable)
                     returnValue = ((IEnumerable)returnValue).Cast<object>().ToArray();

                  ConsoleColor color = Console.ForegroundColor;
                  Console.ForegroundColor = ConsoleColor.DarkGray;
                  
                  ObjectDumper.Write(returnValue, 1, Console.Out);

                  Console.ForegroundColor = color;
               } 
            }
         }
      }

      int GetArrayOption<T>(T[] options, string title, int defaultOption = 0) {

         bool firstTry = true;
         int index = -1;
         int left = Console.CursorLeft;

         while (index < 0 || index >= options.Length) {

            if (!firstTry)
               Console.WriteLine();

            firstTry = false;

            Console.WriteLine();
            Console.WriteLine(title);

            for (int i = 0; i < options.Length; i++) {

               if (i > 0)
                  Console.Write(", ");

               Console.Write("[{0}] {1}", i + 1, options[i]);
            }

            Console.Write(": ");

            left = Console.CursorLeft;
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter) {

               index = defaultOption;

            } else {

               try {
                  index = Int32.Parse(key.KeyChar.ToString()) - 1;
               } catch (Exception) { }
            }
         }

         var prevColor = Console.ForegroundColor;

         Console.ForegroundColor = ConsoleColor.Green;

         Console.CursorLeft = left;
         Console.Write(options[index]);
         Console.WriteLine();

         Console.ForegroundColor = prevColor;

         return index;
      }
      
      void WriteError(Exception ex, bool fatal = false) {

         ConsoleColor prevColor = Console.ForegroundColor;
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine(ex.Message);
         Console.ForegroundColor = prevColor;

         Console.WriteLine();
         Console.WriteLine((fatal) ? "Press key to exit..." : "Press key to continue...");
         Console.ReadKey();
      }
   }
}
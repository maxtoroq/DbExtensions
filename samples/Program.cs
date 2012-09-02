using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using DbExtensions;

namespace SamplesApp {

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

         string[] continueOnErrorOptions = { "Yes", "No" };
         bool continueOnError = GetArrayOption(continueOnErrorOptions, "Continue on Error:") == 0;

         DataAccessObject context;
         Type extensionMethodSamples, sqlBuilderSamples, dataAccessObjectSamples, sqlSetSamples;

         GetSamples(samplesLanguage, connString, mappingSource, out context, out extensionMethodSamples, out sqlBuilderSamples, out dataAccessObjectSamples, out sqlSetSamples);

         context.Configuration.Log = Console.Out;

         Console.WriteLine();
         Console.WriteLine("Press key to begin...");
         Console.ReadKey();

         RunSamples(Activator.CreateInstance(extensionMethodSamples, connString, Console.Out), continueOnError);
         Console.WriteLine();
         Console.WriteLine("Press key to continue...");
         Console.ReadKey();

         RunSamples(Activator.CreateInstance(sqlBuilderSamples), continueOnError);
         Console.WriteLine();
         Console.WriteLine("Press key to continue...");
         Console.ReadKey();

         if (sqlSetSamples != null) {
            RunSamples(Activator.CreateInstance(sqlSetSamples, connString, Console.Out), continueOnError);
            Console.WriteLine();
            Console.WriteLine("Press key to continue...");
            Console.ReadKey(); 
         }

         RunSamples(Activator.CreateInstance(dataAccessObjectSamples, context), continueOnError);
         Console.WriteLine();
         Console.WriteLine("Press key to exit...");
         Console.ReadKey();
      }

      void GetSamples(string language, string connString, MappingSource mappingSource, out DataAccessObject context, out Type extensionMethodSamples, out Type sqlBuilderSamples, out Type dataAccessObjectSamples, out Type sqlSetSamples) {

         MetaModel mapping;
         
         switch (language) {
            case "C#":
               mapping = (mappingSource is AttributeMappingSource) ? mappingSource.GetModel(typeof(Samples.CSharp.Northwind.NorthwindContext)) : mappingSource.GetModel(typeof(Samples.CSharp.Northwind.ForXmlMappingSourceOnlyDataContext));
               context = new Samples.CSharp.Northwind.NorthwindContext(connString, mapping);
               
               extensionMethodSamples = typeof(Samples.CSharp.ExtensionMethodsSamples);
               sqlBuilderSamples = typeof(Samples.CSharp.SqlBuilderSamples);
               dataAccessObjectSamples = typeof(Samples.CSharp.DataAccessObjectSamples);
               sqlSetSamples = typeof(Samples.CSharp.SqlSetSamples);
               break;

            case "VB":
               mapping = (mappingSource is AttributeMappingSource) ? mappingSource.GetModel(typeof(Samples.VisualBasic.Northwind.Product)) : mappingSource.GetModel(typeof(Samples.VisualBasic.Northwind.ForXmlMappingSourceOnlyDataContext));
               context = new Samples.VisualBasic.Northwind.NorthwindContext(connString, mapping);

               extensionMethodSamples = typeof(Samples.VisualBasic.ExtensionMethodsSamples);
               sqlBuilderSamples = typeof(Samples.VisualBasic.SqlBuilderSamples);
               dataAccessObjectSamples = typeof(Samples.VisualBasic.DataAccessObjectSamples);
               sqlSetSamples = null;
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

               SqlBuilder sqlbuilder = returnValue as SqlBuilder;

               if (sqlbuilder != null) {
                  Console.WriteLine(returnValue);
                  for (int j = 0; j < sqlbuilder.ParameterValues.Count; j++) {

                     object value = sqlbuilder.ParameterValues[j];
                     Type type = (value != null) ? value.GetType() : null;

                     Console.WriteLine("-- {0}: {1} [{2}]", j, type, value);
                  }
               } else {
                  ObjectDumper.Write(returnValue, 1, Console.Out);
               } 
            }
         }
      }

      int GetArrayOption<T>(T[] options, string title) {

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

               index = 0;

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
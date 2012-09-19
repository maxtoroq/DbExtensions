using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DbExtensions;

namespace Samples {

   class Program {

      readonly string solutionPath = Path.Combine("..", "..", "..");

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
         ConnectionStringSettings connSettings = connectionStrings[connIndex];
         DbProviderFactory provider = DbFactory.GetProviderFactory(connSettings.ProviderName);
         string connectionString = "name=" + connSettings.Name;

         Console.WriteLine();
         Console.WriteLine("Provider: {0}", provider.GetType().AssemblyQualifiedName);
         Console.WriteLine();
         Console.WriteLine("Connecting...");

         try {
            DbConnection conn = DbFactory.CreateConnection(connectionString);
            using (conn.EnsureOpen())
               Console.WriteLine("Server Version: {0}", conn.ServerVersion);
         } catch (Exception ex) {

            WriteError(ex, fatal: true);
            return;
         }

         string[] samplesLangs = GetSamplesLanguages();

         int samplesLangIndex = GetArrayOption(samplesLangs, "Select the samples language (or Enter):");
         string samplesLanguage = samplesLangs[samplesLangIndex];

         MappingSource[] mappingSources = { new AttributeMappingSource(), XmlMappingSource.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Samples.Northwind.Northwind.xml")) };
         int mappingSourceIndex = GetArrayOption(mappingSources, "Select the mapping source (or Enter):");
         MappingSource mappingSource = mappingSources[mappingSourceIndex];

         object[] samples;

         try {
            samples = GetSamples(samplesLanguage, connectionString, mappingSource, Console.Out).ToArray();
         } catch (Exception ex) {

            WriteError(ex, fatal: true);
            return;
         }

         string[] samplesOptions =
            (from s in samples
             let name = s.GetType().Name
             let friendlyName = name.Substring(0, name.Length - "Samples".Length)
             select friendlyName).Concat(new[] { "All" }).ToArray();

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

      string[] GetSamplesLanguages() {

         string[] projectsDir = Directory
            .GetDirectories(this.solutionPath, @"samples.*", SearchOption.TopDirectoryOnly)
            .Select(s => s.Split(Path.DirectorySeparatorChar).Last())
            .Where(s => s.Contains('.'))
            .ToArray();

         return projectsDir.Select(s => s.Split('.').Skip(1).First()).ToArray();
      }

      IEnumerable<object> GetSamples(string language, string connectionString, MappingSource mappingSource, TextWriter log) {

         string projectDir = Path.Combine(this.solutionPath, "samples." + language);
         string projectFile = Directory.GetFiles(projectDir, String.Format("*.{0}proj", language)).FirstOrDefault();

         if (projectFile == null) 
            throw new InvalidOperationException("Project file not found.");

         string projectFileName = projectFile.Split(Path.DirectorySeparatorChar).Last();
         string assemblyFileName = String.Join(".", projectFileName.Split('.').Reverse().Skip(1).Reverse()) + ".dll";
         string assemblyPath = Path.Combine(projectDir, "bin", "Debug", assemblyFileName);
         Assembly samplesAssembly = Assembly.Load(File.ReadAllBytes(assemblyPath));

         MetaModel mapping;


         if (mappingSource is AttributeMappingSource) {
            mapping = mappingSource.GetModel(
               samplesAssembly.GetTypes()
                  .Where(t => typeof(Database).IsAssignableFrom(t))
                  .Single()
            );
         } else {
            mapping = mappingSource.GetModel(
               samplesAssembly.GetTypes()
                  .Where(t => typeof(System.Data.Linq.DataContext).IsAssignableFrom(t))
                  .Single()
            );
         }

         return 
            from t in samplesAssembly.GetTypes()
            where t.IsPublic
               && t.Name.EndsWith("Samples")
            let parameters = t.GetConstructors().First().GetParameters()
            let args = 
               from p in parameters
               select (p.ParameterType == typeof(string) ? connectionString 
                  : p.ParameterType == typeof(TextWriter) ? log
                  : p.ParameterType == typeof(MetaModel) ? mapping
                  : p.ParameterType == typeof(DbConnection) ? DbFactory.CreateConnection(connectionString)
                  : p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType)
                  : null)
            select Activator.CreateInstance(t, args.ToArray());
      }

      void RunSamples(object samples, bool continueOnError) {

         Type samplesType = samples.GetType();

         List<MethodInfo> methods = samplesType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList();

         for (int i = 0; i < methods.Count; i++) {
            MethodInfo method = methods[i];

            Console.WriteLine();
            Console.WriteLine(method.Name);
            Array.ForEach<char>(method.Name.ToCharArray(), c => Console.Write("="));
            Console.WriteLine();

            object returnValue = null;

            if (method.ReturnType == typeof(void)) {

               var runSample = (Action)Delegate.CreateDelegate(typeof(Action), samples, method);

               if (continueOnError) {

                  try {
                     runSample();
                  } catch (Exception ex) {
                     WriteError(ex);
                     continue;
                  }

               } else {
                  runSample();
               }

            } else {

               Action runSample = () => {
                  returnValue = Expression.Lambda<Func<object>>(
                     Expression.Convert(
                        Expression.Call(Expression.Constant(samples), method)
                        , typeof(object)
                     )
                  ).Compile()();

                  if (returnValue is IEnumerable)
                     returnValue = ((IEnumerable)returnValue).Cast<object>().ToArray();
               };

               if (continueOnError) {

                  try {
                     runSample();
                  } catch (Exception ex) {
                     WriteError(ex);
                     continue;
                  }

               } else {
                  runSample();
               }
            }

            if (returnValue != null) {

               Console.WriteLine();

               var sqlbuilder = returnValue as SqlBuilder;

               if (sqlbuilder != null) {

                  Console.WriteLine(returnValue);

                  for (int j = 0; j < sqlbuilder.ParameterValues.Count; j++) {

                     object value = sqlbuilder.ParameterValues[j];
                     Type type = (value != null) ? value.GetType() : null;

                     Console.WriteLine("-- {0}: {1} [{2}]", j, type, value);
                  }

               } else {

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
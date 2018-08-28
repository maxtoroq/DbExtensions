using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using DbExtensions;

namespace Samples {

   using static Console;

   class Program {

      readonly string samplesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..");

      static void Main() {
         new Program().Run();
      }

      void Run() {

         WriteLine("DbExtensions Sample Runner");
         WriteLine("==========================");

         var connectionStrings = ConfigurationManager.ConnectionStrings
            .Cast<ConnectionStringSettings>()
            // Only connection strings defined in this application config file (not in machine.config)
            .Where(c => c.ElementInformation.Source != null && c.ElementInformation.Source.EndsWith("exe.config", StringComparison.OrdinalIgnoreCase))
            .ToArray();

         int connIndex = GetArrayOption(connectionStrings.Select(c => c.Name).ToArray(), "Select a connection string (or Enter to select the first one):");
         ConnectionStringSettings connSettings = connectionStrings[connIndex];
         DbProviderFactory provider = DbProviderFactories.GetFactory(connSettings.ProviderName);

         WriteLine();
         WriteLine("Provider: {0}", provider.GetType().AssemblyQualifiedName);
         WriteLine();
         WriteLine("Connecting...");

         try {

            var db = new Database(connSettings.ConnectionString, connSettings.ProviderName);

            using (db.EnsureConnectionOpen()) {
               WriteLine("Server Version: {0}", ((DbConnection)db.Connection).ServerVersion);
            }

         } catch (Exception ex) {

            WriteError(ex, fatal: true);
            return;
         }

         string[] samplesLangs = GetSamplesLanguages();

         int samplesLangIndex = GetArrayOption(samplesLangs, "Select the samples language (or Enter):");
         string samplesLanguage = samplesLangs[samplesLangIndex];

         object[] samples;

         try {
            samples = GetSamples(samplesLanguage, connSettings).ToArray();
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

         WriteLine();
         WriteLine("Press key to begin...");
         ReadKey();

         for (int i = 0; i < selectedSamples.Length; i++) {

            object sampl = selectedSamples[i];

            RunSamples(sampl, continueOnError);

            IDisposable disp = sampl as IDisposable;

            if (disp != null) {
               disp.Dispose();
            }

            WriteLine();
            WriteLine((i == selectedSamples.Length - 1) ? "Press key to exit..." : "Press key to continue...");
            ReadKey();
         }
      }

      string[] GetSamplesLanguages() {

         string appDir = AppDomain.CurrentDomain.BaseDirectory
            .Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .Skip(2)
            .First();

         string[] projectsDir = Directory
            .GetDirectories(this.samplesPath, "*", SearchOption.TopDirectoryOnly)
            .Select(s => s.Split(Path.DirectorySeparatorChar).Last())
            .Where(s => !s.Equals(appDir))
            .ToArray();

         return projectsDir;
      }

      IEnumerable<object> GetSamples(string language, ConnectionStringSettings connSettings) {

         string projectDir = Path.Combine(this.samplesPath, language);
         string projectFile = Directory.GetFiles(projectDir, String.Format("*.{0}proj", Regex.Replace(language, "[a-z]", ""))).FirstOrDefault();

         if (projectFile == null) {
            throw new InvalidOperationException("Project file not found.");
         }

         string projectFileName = projectFile.Split(Path.DirectorySeparatorChar).Last();
         string assemblyFileName = String.Join(".", projectFileName.Split('.').Reverse().Skip(1).Reverse()) + ".dll";
         string assemblyPath = new Uri(Path.Combine(projectDir, "bin", "Debug", assemblyFileName)).LocalPath;

         Assembly samplesAssembly = Assembly.LoadFrom(assemblyPath);

         Type dbType = samplesAssembly.GetTypes()
            .Where(t => typeof(Database).IsAssignableFrom(t))
            .Single();

         Database db = (Database)Activator.CreateInstance(dbType, connSettings.ConnectionString, connSettings.ProviderName);
         db.Configuration.Log = Out;

         return
            from t in samplesAssembly.GetTypes()
            where t.IsPublic
               && t.Name.EndsWith("Samples")
            let parameters = t.GetConstructors().First().GetParameters()
            let args =
               from p in parameters
               select (typeof(Database).IsAssignableFrom(p.ParameterType) ? db
                  : p.ParameterType.IsValueType ? Activator.CreateInstance(p.ParameterType)
                  : null)
            select Activator.CreateInstance(t, args.ToArray());
      }

      void RunSamples(object samples, bool continueOnError) {

         Type samplesType = samples.GetType();
         bool isDisposable = samples is IDisposable;

         List<MethodInfo> methods = samplesType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList();

         for (int i = 0; i < methods.Count; i++) {

            MethodInfo method = methods[i];

            if (isDisposable
               && method.Name == "Dispose") {

               continue;
            }

            WriteLine();
            WriteLine(method.Name);
            Array.ForEach<char>(method.Name.ToCharArray(), c => Write("="));
            WriteLine();

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

                  if (returnValue is IEnumerable) {
                     returnValue = ((IEnumerable)returnValue).Cast<object>().ToArray();
                  }
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

               WriteLine();

               var sqlbuilder = returnValue as SqlBuilder;

               if (sqlbuilder != null) {

                  WriteLine(returnValue);

                  for (int j = 0; j < sqlbuilder.ParameterValues.Count; j++) {

                     object value = sqlbuilder.ParameterValues[j];
                     Type type = (value != null) ? value.GetType() : null;

                     WriteLine("-- {0}: {1} [{2}]", j, type, value);
                  }

               } else {

                  ConsoleColor color = ForegroundColor;
                  ForegroundColor = ConsoleColor.DarkGray;

                  ObjectDumper.Write(returnValue, 1, Out);

                  ForegroundColor = color;
               }
            }
         }
      }

      int GetArrayOption<T>(T[] options, string title, int defaultOption = 0) {

         bool firstTry = true;
         int index = -1;
         int left = CursorLeft;

         while (index < 0 || index >= options.Length) {

            if (!firstTry) {
               WriteLine();
            }

            firstTry = false;

            WriteLine();
            WriteLine(title);

            for (int i = 0; i < options.Length; i++) {

               if (i > 0) {
                  Write(", ");
               }

               Write("[{0}] {1}", i + 1, options[i]);
            }

            Write(": ");

            left = CursorLeft;
            var key = ReadKey();

            if (key.Key == ConsoleKey.Enter) {

               index = defaultOption;

            } else {

               try {
                  index = Int32.Parse(key.KeyChar.ToString()) - 1;
               } catch (Exception) { }
            }
         }

         var prevColor = ForegroundColor;

         ForegroundColor = ConsoleColor.Green;

         CursorLeft = left;
         Write(options[index]);
         WriteLine();

         ForegroundColor = prevColor;

         return index;
      }

      void WriteError(Exception ex, bool fatal = false) {

         ConsoleColor prevColor = ForegroundColor;
         ForegroundColor = ConsoleColor.Red;
         WriteLine(ex.Message);
         ForegroundColor = prevColor;

         WriteLine();
         WriteLine((fatal) ? "Press key to exit..." : "Press key to continue...");
         ReadKey();
      }
   }
}
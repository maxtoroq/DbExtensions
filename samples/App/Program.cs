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

      readonly string
      _samplesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..");

      static void
      Main() {

         DbProviderFactories.RegisterFactory("Microsoft.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
         DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", MySql.Data.MySqlClient.MySqlClientFactory.Instance);
         DbProviderFactories.RegisterFactory("System.Data.SQLite", System.Data.SQLite.SQLiteFactory.Instance);

         new Program().Run();
      }

      void
      Run() {

         WriteLine("DbExtensions Sample Runner");
         WriteLine("==========================");

         var connectionStrings = ConfigurationManager.ConnectionStrings
            .Cast<ConnectionStringSettings>()
            // Only connection strings defined in this application config file
            .Where(c => c.ElementInformation.Source != null && c.ElementInformation.Source.EndsWith("dll.config", StringComparison.OrdinalIgnoreCase))
            .ToArray();

         var connIndex = GetArrayOption(connectionStrings.Select(c => c.Name).ToArray(), "Select a connection string (or Enter to select the first one):");
         var connSettings = connectionStrings[connIndex];
         var provider = DbProviderFactories.GetFactory(connSettings.ProviderName);

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

         var samplesLangs = GetSamplesLanguages();

         var samplesLangIndex = GetArrayOption(samplesLangs, "Select the samples language (or Enter):");
         var samplesLanguage = samplesLangs[samplesLangIndex];

         object[] samples;

         try {
            samples = GetSamples(samplesLanguage, connSettings).ToArray();
         } catch (Exception ex) {

            WriteError(ex, fatal: true);
            return;
         }

         var samplesOptions =
            (from s in samples
             let name = s.GetType().Name
             let friendlyName = name.Substring(0, name.Length - "Samples".Length)
             select friendlyName)
             .Append("All")
             .ToArray();

         var samplesIndex = GetArrayOption(samplesOptions, "Select the samples category (or Enter to run all):", samplesOptions.Length - 1);

         var selectedSamples = (samplesIndex == samplesOptions.Length - 1) ? samples
            : [samples[samplesIndex]];

         var continueOnErrorOptions = new[] { "Yes", "No" };
         var continueOnError = GetArrayOption(continueOnErrorOptions, "Continue on Error:") == 0;

         WriteLine();
         WriteLine("Press key to begin...");
         ReadKey();

         for (int i = 0; i < selectedSamples.Length; i++) {

            var sampl = selectedSamples[i];

            RunSamples(sampl, continueOnError);

            if (sampl is IDisposable disp) {
               disp.Dispose();
            }

            WriteLine();
            WriteLine((i == selectedSamples.Length - 1) ? "Press key to exit..." : "Press key to continue...");
            ReadKey();
         }
      }

      string[]
      GetSamplesLanguages() {

         var appDir = AppDomain.CurrentDomain.BaseDirectory
            .Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .Skip(3)
            .First();

         var projectsDir = Directory
            .GetDirectories(_samplesPath, "*", SearchOption.TopDirectoryOnly)
            .Select(s => s.Split(Path.DirectorySeparatorChar).Last())
            .Where(s => !s.Equals(appDir))
            .ToArray();

         return projectsDir;
      }

      IEnumerable<object>
      GetSamples(string language, ConnectionStringSettings connSettings) {

         var projectDir = Path.Combine(_samplesPath, language);
         var projectFile = Directory.GetFiles(projectDir, String.Format("*.{0}proj", Regex.Replace(language, "[a-z]", "")))
            .FirstOrDefault()
            ?? throw new InvalidOperationException("Project file not found.");

         var projectFileName = projectFile.Split(Path.DirectorySeparatorChar).Last();
         var assemblyName = String.Join(".", projectFileName.Split('.').Reverse().Skip(1).Reverse());
         var assemblyDir = Directory.GetDirectories(Path.Combine(projectDir, "bin", "Debug"), "net*").First();
         var assemblyPath = new Uri(Path.Combine(assemblyDir, assemblyName + ".dll")).LocalPath;

         var samplesAssembly = Assembly.LoadFrom(assemblyPath);

         var dbType = samplesAssembly.GetTypes()
            .Where(t => typeof(Database).IsAssignableFrom(t))
            .Single();

         var db = (Database)Activator.CreateInstance(dbType, connSettings.ConnectionString, connSettings.ProviderName);
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

      void
      RunSamples(object samples, bool continueOnError) {

         var samplesType = samples.GetType();
         var isDisposable = samples is IDisposable;

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

               void runSample() {
                  returnValue = Expression.Lambda<Func<object>>(
                     Expression.Convert(
                        Expression.Call(Expression.Constant(samples), method)
                        , typeof(object)
                     )
                  ).Compile()();

                  if (returnValue is IEnumerable ienum) {
                     returnValue = ienum.Cast<object>().ToArray();
                  }
               }

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

               if (returnValue is SqlBuilder sql) {

                  WriteLine(returnValue);

                  for (int j = 0; j < sql.ParameterValues.Count; j++) {

                     var value = sql.ParameterValues[j];
                     var type = value?.GetType();

                     WriteLine("-- {0}: {1} [{2}]", j, type, value);
                  }

               } else {

                  var color = ForegroundColor;
                  ForegroundColor = ConsoleColor.DarkGray;

                  ObjectDumper.Write(returnValue, 1, Out);

                  ForegroundColor = color;
               }
            }
         }
      }

      int
      GetArrayOption<T>(T[] options, string title, int defaultOption = 0) {

         var firstTry = true;
         var index = -1;
         var left = CursorLeft;

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

      void
      WriteError(Exception ex, bool fatal = false) {

         var prevColor = ForegroundColor;
         ForegroundColor = ConsoleColor.Red;
         WriteLine(ex.Message);
         ForegroundColor = prevColor;

         WriteLine();
         WriteLine((fatal) ? "Press key to exit..." : "Press key to continue...");
         ReadKey();
      }
   }
}

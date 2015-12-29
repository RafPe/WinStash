using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extras.AttributeMetadata;
using Newtonsoft.Json;
using WinStash.Core.contracts;
using WinStash.Core.plugins;
using static System.String;

namespace WinStash.Core.config
{
    /// <summary>
    /// Main class used for configuration of application
    /// </summary>
    public class MrConfig
    {
        public static  MasterConfig config => _config;
        private static MasterConfig _config;

        public static  bool isConfigurationValid => _isConfigurationValid;
        private static bool _isConfigurationValid;

        /// <summary>
        /// Method responsible for loading configuration
        /// </summary>
        /// <returns></returns>
        public static bool LoadConfiguration()
        {
            string pathToDefault = @"C:\temp\config.json";
            //string pathToDefault = $"{System.IO.Directory.GetCurrentDirectory()}\\configs\\config.json";

            try
            {
               _config =  JsonConvert.DeserializeObject<MasterConfig>(System.IO.File.ReadAllText( pathToDefault ));
               _isConfigurationValid = true;

                return isConfigurationValid;

            }
            catch(Exception ex)
            {
                return _isConfigurationValid;
            }
        }

        /// <summary>
        /// This method dynamically registers modules with our plugins by scanning for autofac modules
        /// and creating their instances for registration.
        ///
        /// http://devkimchi.com/631/dynamic-module-loading-with-autofac/       
        /// </summary>
        /// <param name="builder">container builder object</param>
        public static void RegisterModules(ContainerBuilder builder)
        {
            // #1
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (IsNullOrWhiteSpace(path))
            {
                return;
            }

            // #2
            var assemblies = Directory.GetFiles($"{AppDomain.CurrentDomain.BaseDirectory}\\plugins", "Plugin.Input*.dll", SearchOption.AllDirectories)
                          .Select(Assembly.LoadFrom);


            foreach (var assembly in assemblies)
            {
                //  #3
                var modules = assembly.GetTypes()
                                      .Where(p => typeof(IModule).IsAssignableFrom(p)
                                                  && !p.IsAbstract)
                                      .Select(p => (IModule)Activator.CreateInstance(p));

                //  #4
                foreach (var module in modules)
                {
                    builder.RegisterModule(module);
                }
            }
        }
    }
}

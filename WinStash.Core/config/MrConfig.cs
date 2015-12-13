using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Extras.AttributeMetadata;
using Newtonsoft.Json;
using WinStash.Core.plugins;

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

                //TODO validate extra ?
               _isConfigurationValid = true;

                return isConfigurationValid;

            }
            catch(Exception ex)
            {
                //TODO: Log we have an exception

                return _isConfigurationValid;
            }
        }


        /// <summary>
        /// Method allowing for loading of input plugins
        /// </summary>
        /// <param name="cb"> ContainerBuilder </param>
        public static void LoadInputPlugins(ContainerBuilder cb)
        {

            // Get assemblies 
            var assemblies = Directory.GetFiles($"{AppDomain.CurrentDomain.BaseDirectory}\\plugins", "Plugin.Input*.dll", SearchOption.AllDirectories)
                          .Select(Assembly.LoadFrom);


            foreach (Assembly assembly in assemblies)
            {
                // Retireve plugin metadata
                var pluginMeta =
                    MetadataHelper.GetMetadata(
                        assembly.GetTypes().FirstOrDefault(p => typeof (IInputPlugin).IsAssignableFrom(p) && p.IsClass));

                cb.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            }
        }

        // http://devkimchi.com/631/dynamic-module-loading-with-autofac/

        /// <summary>
        /// This method dynamically registers modules with our plugins by scanning for autofac modules
        /// and creating their instances for registration.
        /// </summary>
        /// <param name="builder">container builder object</param>
        public static void RegisterModules(ContainerBuilder builder)
        {
            // #1
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (String.IsNullOrWhiteSpace(path))
            {
                return;
            }

            //  #2
            //var assemblies = Directory.GetFiles(path, "Module*.dll", SearchOption.TopDirectoryOnly)
            //                          .Select(Assembly.LoadFrom);

            // Get assemblies 
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

using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.AttributeMetadata;
using WinStash.Core.config;
using WinStash.Core.Plugins;

namespace WinStash.Core
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
            string pathToDefault = $"{System.IO.Directory.GetCurrentDirectory()}\\configs\\config.json";

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

    }
}

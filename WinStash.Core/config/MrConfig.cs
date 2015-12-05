using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
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
        public static List<Type> InputPluginAssemblies => _inputPluginAssemblies;
        private static List<Type> _inputPluginAssemblies;


        public  static   MasterConfig    config
        {
            get
            {
                return _config;
            }
        }
        private static   MasterConfig    _config;


        public  static   bool            ConfigurationValid
        { 
            get
            {
                return _ConfigurationValid;
            }
        }
        private static   bool            _ConfigurationValid = false;
        


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
               _ConfigurationValid = true;

                return _ConfigurationValid;

            }
            catch(Exception ex)
            {
                //TODO: Log we have an exception

                return _ConfigurationValid;
            }
        }


        /// <summary>
        /// Method allowing for loading of input plugins
        /// </summary>
        /// <param name="cb"> ContainerBuilder </param>
        public static void LoadInputPlugins(ContainerBuilder cb)
        {

            // Get assemblies 
            var assemblies = Directory.GetFiles($"{AppDomain.CurrentDomain.BaseDirectory}\\plugins", "Winstash.Input*.dll", SearchOption.TopDirectoryOnly)
                          .Select(Assembly.LoadFrom);


            foreach (Assembly assembly in assemblies)
            {
                // Retireve plugin metadata
                var pluginMeta =
                    MetadataHelper.GetMetadata(
                        assembly.GetTypes().FirstOrDefault(p => typeof (IInputPlugin).IsAssignableFrom(p) && p.IsClass));

                cb.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
            }

            

            //foreach (Assembly assembly in assemblies)
            //{
            //    var singleassembly = assembly.GetTypes().FirstOrDefault(p => typeof(IInputPlugin).IsAssignableFrom(p) && p.IsClass);


            //}

            // Enumarate DLLS in search of input plugins
            //foreach (FileInfo fileinfo in availablePlugins.GetFiles("Winstash.Input*.dll", SearchOption.AllDirectories))
            //{
            //    var singleassembly = Assembly.LoadFile(fileinfo.FullName);
            //    var classtype =
            //        singleassembly.GetTypes().FirstOrDefault(p => typeof(IInputPlugin).IsAssignableFrom(p) && p.IsClass);

            //    _inputPluginAssemblies.Add( classtype );
            //}

        }

    }
}

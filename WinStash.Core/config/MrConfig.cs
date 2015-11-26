using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.config;
using WinStash.Core.Plugins;

namespace WinStash.Core
{
    /// <summary>
    /// Main class used for configuration of application
    /// </summary>
    public static class MrConfig
    {
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
    }
}

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
        public static  MasterConfig config { get; private set; }

        public static bool LoadConfiguration()
        {
            return true;
        }
    }
}

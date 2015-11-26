using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.plugins;

namespace WinStash.Core.Plugins
{
    /// <summary>
    /// This interface defines minimum required for Input plugin
    /// </summary>
    public interface IInputPlugin : IPlugin
    {
        
        int     interval    { get; }

        string QueryForData(); 
    }
}

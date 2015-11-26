using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.Plugins
{
    /// <summary>
    /// This interface defines minimum required for Input plugin
    /// </summary>
    public interface IInputPlugin
    {
        string  key         { get; }
        string  pluginType  { get; }
        int     interval    { get; }

        string QueryForData(); 
    }
}

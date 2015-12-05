using System.Collections.Generic;
using WinStash.Core.plugins;

namespace WinStash.Core.Plugins
{
    /// <summary>
    /// This interface defines minimum required for Input plugin
    /// </summary>
    public interface IInputPlugin : IPlugin
    {

        List<Dictionary<string, object>> QueryForData(); 
    }
}

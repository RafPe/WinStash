using System.Collections;
using System.Collections.Generic;

namespace WinStash.Core.plugins
{
    /// <summary>
    /// This interface defines minimum required for Input plugin
    /// </summary>
    public interface IInputPlugin : IPlugin
    {

        List<IDictionary> QueryForData(); 
    }
}

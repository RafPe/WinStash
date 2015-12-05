using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.Plugins;

namespace Plugin.Input.WinEvent
{
    public interface IWinEvent : IInputPlugin
    {
        string key          { get; }
    }
}

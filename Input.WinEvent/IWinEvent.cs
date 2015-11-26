using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.Plugins;

namespace Input.WinEvent
{
    public interface IWinEvent : IInputPlugin
    {
        string key          { get; }
        string LogName      { get; }
        string FilterQuery  { get; }
    }
}

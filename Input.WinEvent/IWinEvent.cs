using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.Plugins;

namespace Winstash.Input
{
    public interface IWinEvent : IInputPlugin
    {
        string key          { get; }
    }
}

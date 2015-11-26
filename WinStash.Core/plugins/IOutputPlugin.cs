using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.Plugins
{
    public interface IOutputPlugin
    {
        string pluginType { get; }  // For example generic,file,json,elastic,network etc ...
    }
}

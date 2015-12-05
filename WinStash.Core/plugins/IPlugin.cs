using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.plugins
{
    public interface IPlugin
    {
        string key          { get; }
    }
}

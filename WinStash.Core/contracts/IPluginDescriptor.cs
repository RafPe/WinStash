using System;
using System.Collections.Generic;

namespace WinStash.Core.contracts
{
    public interface IPluginDescriptor
    {
        IEnumerable<KeyValuePair<string, object>> pluginMeta          { get; }
        Type                        implementedType     { get; }
    }
}

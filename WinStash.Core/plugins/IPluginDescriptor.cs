using System;
using System.Collections.Generic;

namespace WinStash.Core.plugins
{
    public interface IPluginDescriptor
    {
        IEnumerable<KeyValuePair<string, object>> pluginMeta          { get; }
        Type                        implementedType     { get; }
    }
}

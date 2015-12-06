using System;
using System.Collections.Generic;

namespace WinStash.Core.plugins
{
    public class PluginDescriptor : IPluginDescriptor
    {
        private IEnumerable<KeyValuePair<string, object>> _pluginMeta;
        private Type            _implementedType;


        public IEnumerable<KeyValuePair<string, object>> pluginMeta
        {
            get { return _pluginMeta; }
            set { _pluginMeta = value; }
        }

        public Type implementedType
        {
            get { return _implementedType; }
            set { _implementedType = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Autofac.Extras.AttributeMetadata;

namespace WinStash.Core.plugins
{
    public class PluginMetadata
    {
        public string pluginType { get; set; }
    }

    [MetadataAttribute]
    public class PluginTypeAttribute : Attribute, IMetadataProvider
    {

        public PluginTypeAttribute(string type, string name)
        {
            this.pluginType = type;
            this.pluginName = name;
        }

        public IDictionary<string, object> GetMetadata(Type targetType)
        {
            return new Dictionary<string, object>()
                {
                    { "Name", this.pluginName },
                    { "pluginType" , this.pluginType }
                };
        }

        public string pluginType { get; }
        public string pluginName { get; }
    }
}

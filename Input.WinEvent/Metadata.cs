using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.AttributeMetadata;

namespace Plugin.Input.WinEvent
{
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

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.AttributeMetadata;

namespace WinStash.Core.plugins
{
    [MetadataAttribute]
    public class PluginTypeAttribute : Attribute, IMetadataProvider
    {
        
        public PluginTypeAttribute(string v)
        {
            this.pluginType = v;
        }

        public IDictionary<string, object> GetMetadata(Type targetType)
        {
            return new Dictionary<string, object>()
                {
                    { "Name", "test me" },
                    { "pluginType" , this.pluginType }
                };
        }

        public string pluginType { get; }
    }
}

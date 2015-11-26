using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.config
{
    public abstract class BaseConfig
    {
        public string                       pluginType { get; set; }
        public Dictionary<string, string>   configuration   { get; set; }

        /// <summary>
        /// Default constructor for our base class
        /// </summary>
        public BaseConfig()
        {
            this.configuration = new Dictionary<string, string>() { { "key", "default_value" } };

        }
    }

    public class InputConfig : BaseConfig
    {
        public InputConfig()
        {
            
        }
    }

    public class OutputConfig : BaseConfig
    {
        public OutputConfig()
        {
       
        }
    }

    public class MasterConfig
    {
        public List<InputConfig>  inputs { get; set; }
        public List<OutputConfig> outputs { get; set; }

        public MasterConfig()
        {
            this.inputs     = new List<InputConfig>();
            this.outputs    = new List<OutputConfig>();
        }
    }
}

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
    }

    public class MasterInputConfig : BaseConfig
    {
        public MasterInputConfig()
        {
            this.configuration = new Dictionary<string, string>();
        }
    }

    public class MasterOutputConfig : BaseConfig
    {
        public MasterOutputConfig()
        {
            this.configuration = new Dictionary<string, string>();           
        }
    }

    public class MasterConfig
    {
        public List<MasterInputConfig>  inputs { get; set; }
        public List<MasterOutputConfig> outputs { get; set; }

        public MasterConfig()
        {
            this.inputs     = new List<MasterInputConfig>();
            this.outputs    = new List<MasterOutputConfig>();
        }
    }
}

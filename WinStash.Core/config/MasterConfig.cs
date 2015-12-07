using System.Collections.Generic;

namespace WinStash.Core.config
{
    public abstract class BaseConfig
    {
        public string                       pluginType      { get; set; }
        public Dictionary<string, object>   configuration   { get; set; }

    }

    public class InputConfig : BaseConfig
    {
    }

    public class FilterConfig : BaseConfig
    {
    }

    public class OutputConfig : BaseConfig
    {
    }


    public class MasterConfig
    {
        public List<InputConfig>  inputs { get; set; }
        public List<FilterConfig> filters { get; set; }
        public List<OutputConfig> outputs { get; set; }

        public MasterConfig()
        {
            this.inputs     = new List<InputConfig>();
            this.outputs    = new List<OutputConfig>();
        }
    }
}

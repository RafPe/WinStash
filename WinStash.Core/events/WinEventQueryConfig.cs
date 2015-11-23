using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.Interfaces;

namespace WinStash.Core.model
{
    public class WinEventQueryConfig : IWinEventQueryConfig
    {
        public string LogName { get; set; }
        public string FilterQuery { get; set; }
        public string ProviderName { get; set; }
        public DateTime TimestampCreatedAfter { get; set; }
        public DateTime TimestampCreatedBefore { get; set; }
        public int LogLevel { get; set; }
    }
}

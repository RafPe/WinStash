using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.Interfaces
{
    public interface IWinEventQueryConfig
    {
        string      LogName                 { get; set; }
        string      FilterQuery             { get; set; }
        string      ProviderName            { get; set; }
        DateTime    TimestampCreatedAfter   { get; set; }
        DateTime    TimestampCreatedBefore  { get; set; }
        int         LogLevel                { get; set; }
    }
}

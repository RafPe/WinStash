using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.Interfaces
{
    /// <summary>
    /// This interface defines methods and properties used during query.
    /// By implementing this you will be able to define method used for windows event log query
    /// </summary>
    public interface IWinEventQuerySrvc
    {
        /// <summary>
        /// This method will be called to query for windows events
        /// </summary>
        /// <returns> List of EventRecord </returns>
        List<EventRecord> QueryWindowsEvents();
    }
}

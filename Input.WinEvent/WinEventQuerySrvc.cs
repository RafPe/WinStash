namespace WinStash.Core.events
{
    //public class WinEventQuerySrvc : IWinEventQuerySrvc
    //{
    //    private IWinEventQueryConfig _cfg;                  // Configuration which should be used for this action

    //    /// <summary>
    //    /// Constructor with parameter for configuration
    //    /// </summary>
    //    /// <param name="cfg"> Our configuration </param>
    //    public WinEventQuerySrvc(IWinEventQueryConfig cfg)
    //    {
    //        _cfg = cfg;
    //    }

    //    public List<EventRecord> QueryWindowsEvents()
    //    {
    //        List<EventRecord> eventRecords = new List<EventRecord>();   // Create a list to hold results 
    //        //EventRecord eventRecord;
    //        //string queryString = String.Format(
    //        //    "*[System[(Level = {0}) and Provider[@Name = '{1}'] and TimeCreated[@SystemTime >= '{2}'] and TimeCreated[@SystemTime <= '{3}']]]",
    //        //    (int)level,
    //        //    providerName,
    //        //    afterTimestamp.ToUniversalTime().ToString("o"),
    //        //    beforeTimestamp.ToUniversalTime().ToString("o"));

    //        //EventLogQuery query = new EventLogQuery(logName, PathType.LogName, queryString);
    //        //EventLogReader reader = new EventLogReader(query);
    //        //while ((eventRecord = reader.ReadEvent()) != null)
    //        //{
    //        //    eventRecords.Add(eventRecord);
    //        //}

    //        return eventRecords;
    //    }
    //}
    
}

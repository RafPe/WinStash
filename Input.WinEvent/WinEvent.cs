using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.plugins;
using WinStash.Core.Plugins;
using EventLevel = System.Diagnostics.Eventing.Reader.EventLevel;

namespace Winstash.Input
{
    [PluginType("winevent","WinEvent")]
    public class WinEvent : IWinEvent
    {
        public WinEvent()
        {
            

        }

        public string key
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<Dictionary<string, object>> QueryForData()
        {

            int tmplevel = 4;
            string tmpLogName = "System";
            string tmpProviderName = "Microsoft-Windows-Kernel-General";

            List<EventRecord> eventRecords = new List<EventRecord>();   // Create a list to hold results 
            EventRecord eventRecord;
            string queryString = String.Format(
            "*[System[(Level = {0}) and Provider[@Name = '{1}']" +
            " and TimeCreated[@SystemTime >= '{2}'] and TimeCreated[@SystemTime <= '{3}']]]",
            4,
            tmpProviderName,
            DateTime.Now.AddDays(-1).ToUniversalTime().ToString("o"),
            DateTime.Now.ToUniversalTime().ToString("o"));


            EventLogQuery query = new EventLogQuery(tmpLogName, PathType.LogName, queryString);

            // Dictionary to hold our results
            var dataList = new List<Dictionary<string, object>>();

            EventLogReader reader = new EventLogReader(query);
            while ((eventRecord = reader.ReadEvent()) != null)
            {

                var kvpdata = new  Dictionary<string, object>();

                kvpdata.Add("timestamp_utc",eventRecord.TimeCreated?.ToUniversalTime().ToString("O") );
                kvpdata.Add("loglevel", eventRecord.LevelDisplayName);
                kvpdata.Add("logname", eventRecord.LogName);
                kvpdata.Add("host", eventRecord.MachineName);
                kvpdata.Add("threadId", eventRecord.ThreadId?.ToString());
                kvpdata.Add("Id", eventRecord.Id.ToString());
                kvpdata.Add("message", eventRecord.FormatDescription());

                dataList.Add(kvpdata);

                eventRecords.Add(eventRecord);
            }

            return dataList;
        }
    }
}

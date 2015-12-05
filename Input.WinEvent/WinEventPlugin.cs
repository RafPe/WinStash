using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.data;
using WinStash.Core.plugins;
using WinStash.Core.Plugins;
using EventLevel = System.Diagnostics.Eventing.Reader.EventLevel;

namespace Plugin.Input.WinEvent
{
    [PluginType("winevent","WinEvent")]
    public class WinEventPlugin : IWinEvent
    {
        public WinEventPlugin()
        {
            

        }

        public string key
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<EventDictionary> QueryForData()
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
            List<EventDictionary> dataList = new List<EventDictionary>();

            EventLogReader reader = new EventLogReader(query);
            while ((eventRecord = reader.ReadEvent()) != null)
            {
                var singleEvent = new EventDictionary();

                singleEvent[EventProperties.message] = eventRecord.FormatDescription();
                singleEvent[EventProperties.Id] = eventRecord.Id.ToString();
                singleEvent[EventProperties.threadId] = eventRecord.ThreadId?.ToString();
                singleEvent[EventProperties.host] = eventRecord.MachineName;
                singleEvent[EventProperties.logname] = eventRecord.LogName;
                singleEvent[EventProperties.loglevel] = eventRecord.LevelDisplayName;
                singleEvent[EventProperties.timestamp_utc] = eventRecord.TimeCreated?.ToUniversalTime().ToString("O");

                //uuu.timestamp_utc = eventRecord.TimeCreated?.ToUniversalTime().ToString("O");


                //var kvpdata = new  Dictionary<string, object>();

                //kvpdata.Add("timestamp_utc", );
                //kvpdata.Add("loglevel", );
                //kvpdata.Add("logname", );
                //kvpdata.Add("host", );
                //kvpdata.Add("", );
                //kvpdata.Add("Id", );
                //kvpdata.Add("message", );

                dataList.Add(singleEvent);

                //eventRecords.Add(eventRecord);
            }

            return dataList;
        }
    }
}

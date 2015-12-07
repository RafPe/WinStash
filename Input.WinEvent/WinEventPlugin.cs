using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Xml.Linq;
using WinStash.Core.data;

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

            int tmplevel = 0;
            string tmpLogName = "Security";
            string tmpProviderName = "Microsoft-Windows-Security-Auditing";

            List<EventRecord> eventRecords = new List<EventRecord>();   // Create a list to hold results 
            EventRecord eventRecord;
            //string queryString = String.Format(
            //"*[System[(Level = {0}) and Provider[@Name = '{1}']" +
            //" and TimeCreated[@SystemTime >= '{2}'] and TimeCreated[@SystemTime <= '{3}']]]",
            string queryString = "*[System/Provider/@Name=\"Microsoft-Windows-Security-Auditing\"]";
            //4,
            //tmpProviderName,
            //DateTime.Now.AddDays(-1).ToUniversalTime().ToString("o"),
            //DateTime.Now.ToUniversalTime().ToString("o"));


            EventLogQuery query = new EventLogQuery(tmpLogName, PathType.LogName, queryString);

            // Dictionary to hold our results
            List<EventDictionary> dataList = new List<EventDictionary>();

            EventLogReader reader = new EventLogReader(query);
            while ((eventRecord = reader.ReadEvent()) != null)
            {
                var singleEvent = new EventDictionary();

                try
                {
                    string evtXml = eventRecord.ToXml();

                    

                    XDocument ususu = XDocument.Parse(evtXml);


                    var feioufoidsfuo = ususu.Root.DescendantNodes();

                    var tststs = ususu.Descendants("EventData");

                    var niewiem = from evt in ususu.Descendants("EventData")
                                  select new
                                  {
                                      rokko = evt.Attribute("name").Value,
                                      bakko = evt.Attributes()
                                  };
                }
                catch (Exception ex )
                {

                    throw; 
                }
                




                // Array of strings containing XPath references
                String[] xPathRefs = new String[1];
                xPathRefs[0] = "Event/System/Task";

                // Place those strings in an IEnumberable object
                IEnumerable<String> xPathEnum = xPathRefs;


                // Create the property selection context using the XPath reference
                EventLogPropertySelector logPropertyContext = new EventLogPropertySelector(xPathEnum);

                var ccc = (EventLogRecord) eventRecord;
                var yyyy = ccc.GetPropertyValues(logPropertyContext);

  


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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Xml.Linq;
using WinStash.Core.data;

namespace Plugin.Input.WinEvent
{
    [PluginType("winevent","WinEvent")]
    public class WinEventPlugin : IWinEventPlugin
    {
        private string g;

        public WinEventPlugin()
        {
            g = Guid.NewGuid().ToString();
        }

        public string key
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<IDictionary> QueryForData()
        {
            var y = new Dictionary<string, string>();
            y.Add("guid","winevt "+g);

            return new List<IDictionary>() { y };


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

            // Create reader and execute query
            EventLogReader reader = new EventLogReader(query);
            while ((eventRecord = reader.ReadEvent()) != null)
            {
                // Process every event

                EventDictionary eventDictionary = new EventDictionary();

                eventDictionary[WinEventProperties.message]         = eventRecord.FormatDescription();
                eventDictionary[WinEventProperties.Id]              = eventRecord.Id.ToString();
                eventDictionary[WinEventProperties.threadId]        = eventRecord.ThreadId?.ToString();
                eventDictionary[WinEventProperties.host]            = eventRecord.MachineName;
                eventDictionary[WinEventProperties.logname]         = eventRecord.LogName;
                eventDictionary[WinEventProperties.loglevel]        = eventRecord.LevelDisplayName;
                eventDictionary[WinEventProperties.timestamp_utc]   = eventRecord.TimeCreated?.ToUniversalTime().ToString("O");

                eventDictionary.AddDictionaryEventProperties(this.ParseSingleEventrecord(eventRecord) );

                dataList.Add(eventDictionary);

            }

            // return results
            return new List<IDictionary>(dataList);
        }

        /// <summary>
        /// Method is reponsible for parsing WindowsEvent XML 
        /// into dictionary of Key/Value string string 
        /// </summary>
        /// <param name="eventRecord">Single event record object</param>
        /// <returns> Dictionary</returns>
        private Dictionary<string, string> ParseSingleEventrecord(EventRecord eventRecord)
        {

            try
            {
                string evtStrXml = eventRecord.ToXml();

                XDocument xml = XDocument.Parse(evtStrXml);
                XNamespace ns = "http://schemas.microsoft.com/win/2004/08/events/event";

                var eventData = (from message in xml.Descendants(ns + "Data")
                                    select new
                                    {
                                        Key = (string)message.Attribute("Name"),
                                        Value = message.Value
                                    }).ToDictionary(mc => mc.Key.ToString(),
                                 mc => mc.Value.ToString(),
                                 StringComparer.OrdinalIgnoreCase);

                return eventData;


            }
            catch (Exception ex)
            {
                //TODO add logging here
                return null;
            }
            

        } 
    }
}

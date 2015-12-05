using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.data
{

    /// <summary>
    /// This class is used to have template for specific fields we return from events in windows 
    /// It might be that this become unnecessary in future - still to think of :) 
    /// </summary>
    public class EventDictionary : Dictionary<string, object>
    {
        /// <summary>
        /// Default constructor making sure we have required fields in our dictionary
        /// </summary>
        public EventDictionary()
        {

            Type type = typeof(EventProperties);        // EventProperties is static class with static properties
            foreach (var p in type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic))
            {
                var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                Console.WriteLine(v.ToString());

                this.Add(v.ToString(),"");
            }

            
            //this.Add("timestamp_utc",this.timestamp_utc??"");
            //this.Add("loglevel",this.loglevel??"");
            //this.Add("logname",this.logname??"");
            //this.Add("host",this.host??"");
            //this.Add("Id",this.Id??"");
            //this.Add("threadId",this.threadId??"");
        }
    }
}

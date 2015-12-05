using System;
using System.Collections.Generic;
using System.Linq;
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
        public string message { get; set; }

        public EventDictionary()
        {
            this.Add("message","");
        }
    }
}

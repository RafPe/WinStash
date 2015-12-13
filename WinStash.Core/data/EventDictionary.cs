using System;
using System.Collections.Generic;

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

            Type type = typeof(WinEventProperties);        // EventProperties is static class with static properties
            foreach (var p in type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic))
            {
                var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                Console.WriteLine(v.ToString());

                this.Add(v.ToString(),"");
            }
        }

        /// <summary>
        /// Method adding remaining properties to our dictionary
        /// </summary>
        /// <param name="props"></param>
        public void AddDictionaryEventProperties(Dictionary<string, string> props)
        {
            if (ReferenceEquals(null, props)) return;

            // Enumrate dictionary and adds it as members of this instance
            foreach (KeyValuePair<string, string> pair in props)
            {

                this.Add(pair.Key, pair.Value);

            }
        }
    }
}

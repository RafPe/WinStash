using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.contracts;

namespace WinStash.Core.data
{
    public class BookKeeper : IBookKeeper
    {
        private Dictionary<string, object> _objects;

        public BookKeeper()
        {
            _objects = new Dictionary<string, object>();
        }

        /// <summary>
        /// Add entry to our object holder
        /// </summary>
        /// <param name="key"> unique key to be used </param>
        /// <param name="value"> value </param>
        public void AddEntry(string key, object value)
        {
            try
            {
                _objects.Add(key, value);
            }
            catch (Exception)
            {
                
                //TODO 10: Handle this error exception
                
            }
        }

        /// <summary>
        /// Return value based on specific key
        /// </summary>
        /// <param name="key"> unique key </param>
        /// <returns></returns>
        public object GetEntryValue(string key)
        {
            return _objects[key] ?? null;
        }
    }
}

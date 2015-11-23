using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinStash.Core.Interfaces;

namespace WinStash.Core
{
    /// <summary>
    /// Class used for core configuration of our input for WinStash 
    /// </summary>
    public class WinStashCoreConfig : IWinStashCoreConfig
    {

        public string                       _source     { get; set; }
        public List<IWinEventQueryConfig>   _configs    { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="source"> Depending on our implementation this is source of our config </param>
        public WinStashCoreConfig(string source)
        {
            _source = source;
        }

        /// <summary>
        /// This service should read and process all configurations available for WinStash
        /// </summary>
        public void QueryForConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}

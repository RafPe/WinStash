using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.Interfaces
{
    /// <summary>
    /// Interface used for configuration read - there should be one of this instances for whole 
    /// initialization
    /// </summary>
    public interface IWinStashCoreConfig
    {
        string                      _source     { get; set; } // Source of our config i.e. .config.json or http://my.api.com/Configs/WinStash?Host=ABC-001
        List<IWinEventQueryConfig>  _configs    { get; set; } // List of our configs which we have read from source

        void    QueryForConfiguration();


    }

    
}

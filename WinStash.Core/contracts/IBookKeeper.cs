using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinStash.Core.contracts
{
    public interface IBookKeeper
    {
        void    AddEntry(string key, object value);
        object  GetEntryValue(string key);
    }
}

using WinStash.Core.contracts;
using WinStash.Core.plugins;

namespace Plugin.Input.WinEvent
{
    public interface IWinEventPlugin : IInputPlugin
    {
        string key          { get; }
    }
}

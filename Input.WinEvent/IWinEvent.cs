using WinStash.Core.Plugins;

namespace Plugin.Input.WinEvent
{
    public interface IWinEvent : IInputPlugin
    {
        string key          { get; }
    }
}

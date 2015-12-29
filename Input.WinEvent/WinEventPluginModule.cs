using Autofac;
using WinStash.Core.contracts;
using WinStash.Core.plugins;

namespace Plugin.Input.WinEvent
{
    public class WinEventPluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WinEventPlugin>().Named<IInputPlugin>("winevent").As<IInputPlugin>();
        }
    }

}

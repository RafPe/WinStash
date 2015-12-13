using Autofac;
using WinStash.Core.plugins;

namespace Plugin.Input.File
{
    public class FilePluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FilePlugin>().Named<IInputPlugin>("file").As<IInputPlugin>();
        }
    }
}

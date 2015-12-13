using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Plugin.Input.WinEvent
{
    public class WinEventModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WinEventPlugin>().As<IWinEvent>();
        }
    }

}

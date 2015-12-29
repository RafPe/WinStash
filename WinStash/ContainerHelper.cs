using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WinStash.Core.config;
using WinStash.Core.contracts;

namespace WinStash
{
    public class ContainerHelper
    {
        public static IContainer Container;

        public static void Build()
        {

            // Create our container builder 
            var builder = new ContainerBuilder();

            // Register basics needed by WinStash
            builder.RegisterType<WinStashSrvc>();
            builder.RegisterType<IBookKeeper>().As<IBookKeeper>().SingleInstance();

            // We register externally delivered modules
            MrConfig.RegisterModules(builder);

            // Build our container 
            Container = builder.Build();

            // Register so we can use Icontainer 
            var builder2 = new ContainerBuilder();
            builder2.RegisterInstance<IContainer>(Container);
            builder2.Update(Container);

        }

        //TODO 2: Add method to resolve from this ?


    }
}

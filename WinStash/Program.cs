using System;
using System.Collections.Generic;
using Autofac;
using Topshelf;
using WinStash.Core.config;
using WinStash.Core.contracts;
using WinStash.Core.plugins;

namespace WinStash
{
    class Program
    {

        static void Main(string[] args)
        {

            // #1 Run Autofac
            ContainerHelper.Build();

            // #2 Load configurations
            MrConfig.LoadConfiguration();

            // #3 Start Topshelf - as a service
            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<WinStashSrvc>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(() => ContainerHelper.Container.Resolve<WinStashSrvc>());
                    serviceConfigurator.WhenStarted(myService => myService.Start());
                    serviceConfigurator.WhenStopped(myService => myService.Stop());
                });

                hostConfigurator.RunAsLocalSystem();                
                hostConfigurator.SetDisplayName("WinStash");
                hostConfigurator.SetDescription("Windows Logging tool");
                hostConfigurator.SetServiceName("WinStash");
            });


        }
    }
}

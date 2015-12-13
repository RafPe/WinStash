using System;
using System.Collections.Generic;
using Autofac;
using WinStash.Core.config;
using WinStash.Core.plugins;

namespace WinStash
{
    class Program
    {

        static void Main(string[] args)
        {

            // Create our container builder 
            var builder = new ContainerBuilder();

            // Load configs and plugins 
           // MrConfig.LoadInputPlugins(builder);

            builder.RegisterType<WinStashSrvc>();

            MrConfig.RegisterModules(builder);
            MrConfig.LoadConfiguration();


            // Build our container 
            var container = builder.Build();

            // Register so we can use Icontainer 
            var builder2 = new ContainerBuilder();
            builder2.RegisterInstance<IContainer>(container);
            builder2.Update(container);


            do
            {


                // Create scope for this execution
                using (var scope = container.BeginLifetimeScope())
                {
                    var service = scope.Resolve<IEnumerable<IInputPlugin>>();

                    try
                    {

                            var plugin = scope.ResolveNamed<IInputPlugin>("winevent");

                            var res = plugin.QueryForData();

                            Console.WriteLine(res[0]["Id"].ToString());

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            } while (true);

            //HostFactory.Run(hostConfigurator =>
            //{
            //    hostConfigurator.Service<WinStashSrvc>(serviceConfigurator =>
            //    {
            //        serviceConfigurator.ConstructUsing(() => container.Resolve<WinStashSrvc>());
            //        serviceConfigurator.WhenStarted(myService => myService.Start());
            //        serviceConfigurator.WhenStopped(myService => myService.Stop());
            //    });

            //    hostConfigurator.RunAsLocalSystem();

            //    hostConfigurator.SetDisplayName("WinStash");
            //    hostConfigurator.SetDescription("Windows Logging tool");
            //    hostConfigurator.SetServiceName("WinStash");
            //});


        }
    }
}

using System;
using System.Collections.Generic;
//using Topshelf;
using WinStash.Core.config;
using Newtonsoft.Json;
using WinStash.Core;

namespace WinStash
{
    class Program
    {
        static void Main(string[] args)
        {

            MrConfig.LoadConfiguration();


            Console.WriteLine($"I have the following number of inputs : {MrConfig.config.inputs.Count}");

            foreach (var singleConfig in MrConfig.config.inputs)
            {
                Console.WriteLine($"Input type : {singleConfig.pluginType}");
            }

            Console.ReadLine();


            //HostFactory.Run(hostConfigurator =>
            //{
            //    hostConfigurator.Service<WinStashSrvc>(serviceConfigurator =>
            //    {
            //        serviceConfigurator.ConstructUsing(() => new WinStashSrvc());
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

using System;
using System.Collections.Generic;
//using Topshelf;
using WinStash.Core.config;
using Newtonsoft.Json;

namespace WinStash
{
    class Program
    {
        static void Main(string[] args)
        {

            var test = new MasterConfig();

            test.inputs.Add(new MasterInputConfig()
            {
                pluginType = "windowsevent",
                configuration = new Dictionary<string, string>()
                                {
                                    { "test", "test" },
                                    { "test2", "test2" }

                                }
            });

            test.outputs.Add(new MasterOutputConfig()
            {
                pluginType = "json",
                configuration = new Dictionary<string, string>()
                                {
                                    { "test", "test" },
                                    { "test2", "test2" }

                                }
            });

            var text = JsonConvert.SerializeObject(test);

           // var test2 = 

            Console.WriteLine("Hello from WinStash :)");
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

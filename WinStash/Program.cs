using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WinStash
{
    class Program
    {
        static void Main(string[] args)
        {


            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<WinStashSrvc>(serviceConfigurator =>
                {
                    serviceConfigurator.ConstructUsing(() => new WinStashSrvc());
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

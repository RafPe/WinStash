using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using Autofac;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.Metadata;
//using Topshelf;
using WinStash.Core.config;
using Newtonsoft.Json;
using Topshelf;
using WinStash.Core;
using WinStash.Core.data;
using WinStash.Core.plugins;
using WinStash.Core.Plugins;

namespace WinStash
{
    class Program
    {

        static void Main(string[] args)
        {

            // Create our container builder 
            var builder = new ContainerBuilder();

            builder.RegisterType<WinStashSrvc>();

            // Load configs and plugins 
            MrConfig.LoadInputPlugins(builder);            
            MrConfig.LoadConfiguration();


            // Build our container 
            var container = builder.Build();

            // Register so we can use Icontainer 
            var builder2 = new ContainerBuilder();
            builder2.RegisterInstance<IContainer>(container);
            builder2.Update(container);


            //var dataAccess = Assembly.GetExecutingAssembly();



            //builder.RegisterAssemblyTypes(dataAccess)
            //       .Where(t => t.Name.StartsWith("Winstash.Input"))
            //       .AsImplementedInterfaces();





            //List<Type> inmplementedTypes = null;
            //List<PluginDescriptor> descriptors = new List<PluginDescriptor>();


            //foreach (FileInfo fileInfo in availablePlugins.GetFiles("*put.*.dll", SearchOption.AllDirectories))
            //{
            //    var singleAssembly = Assembly.LoadFile(fileInfo.FullName);
            //    var classType =
            //        singleAssembly.GetTypes()
            //            .FirstOrDefault(p => typeof (IInputPlugin).IsAssignableFrom(p) && p.IsClass);

            //    PluginDescriptor myvar = new PluginDescriptor()
            //    {
            //        implementedType = classType,
            //        pluginMeta = MetadataHelper.GetMetadata(classType)
            //    };


            //var container = builder.Build();

            //var neinie = container.Resolve<IEnumerable<IInputPlugin>>();

            //foreach (IInputPlugin inputPlugin in neinie)
            //{


            //    foreach (EventDictionary evtd in inputPlugin.QueryForData())
            //    {
            //        Console.WriteLine($"EVT : {evtd[EventProperties.Id]} about {evtd[EventProperties.timestamp_utc]}");
            //    }
            //}

            //Console.ReadLine();

            //var u = "";
            //var ssss = descriptors[0].implementedType;



            //var instance = (IInputPlugin) container.Resolve();

            // Here we  should get test information now 
            // Console.WriteLine( cc.QueryForData() );











            //Console.WriteLine($"I have the following number of inputs : {MrConfig.config.inputs.Count}");

            //foreach (var singleConfig in MrConfig.config.inputs)
            //{
            //    Console.WriteLine($"Input type : {singleConfig.pluginType}");
            //}




            HostFactory.Run(hostConfigurator =>
            {
                hostConfigurator.Service<WinStashSrvc>(serviceConfigurator =>
                {
                    //serviceConfigurator.ConstructUsing(() => new WinStashSrvc());
                    serviceConfigurator.ConstructUsing(() => container.Resolve<WinStashSrvc>());
                    serviceConfigurator.WhenStarted(myService => myService.Start());
                    serviceConfigurator.WhenStopped(myService => myService.Stop());
                });

                hostConfigurator.RunAsLocalSystem();

                hostConfigurator.SetDisplayName("WinStash");
                hostConfigurator.SetDescription("Windows Logging tool");
                hostConfigurator.SetServiceName("WinStash");
            });


        }

        //private static void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    using (var scope = container.BeginLifetimeScope())
        //    {
        //        service = scope.Resolve<IInputPlugin>();

        //        var resultos = service.QueryForData();

        //        foreach (Dictionary<string, object> dictionary in resultos)
        //        {
        //            Console.WriteLine($"This message comes as : {dictionary["message"]}");
        //        }

        //        Console.ReadLine();
        //    }
        //}
    }
}

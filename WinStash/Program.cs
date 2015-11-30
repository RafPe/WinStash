using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
//using Topshelf;
using WinStash.Core.config;
using Newtonsoft.Json;
using WinStash.Core;
using WinStash.Core.Plugins;

namespace WinStash
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create our container builder 
            var builder = new ContainerBuilder();

            

            // get folder with plugins 
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var availablePlugins = new DirectoryInfo($"{folder}\\plugins");


            List<Type> inmplementedTypes = null;


            foreach (FileInfo fileInfo in availablePlugins.GetFiles("input.*.dll", SearchOption.AllDirectories))
            {
                var singleAssembly = Assembly.LoadFile(fileInfo.FullName);

                inmplementedTypes = singleAssembly.GetTypes().Where(p => typeof(IInputPlugin).IsAssignableFrom(p) && p.IsClass).ToList();

                builder.RegisterAssemblyTypes( singleAssembly )
                    .Where(t => t.Name.StartsWith("Input"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }

            // build our container with dependencies
            var container = builder.Build();

            // Test resolving of components 
            var scope = container.BeginLifetimeScope();

            var type = Type.GetType(inmplementedTypes[0].Name);
            IInputPlugin instance = (IInputPlugin) container.Resolve(type);

            // Here we  should get test information now 
            instance.QueryForData();



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

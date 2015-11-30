using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.Metadata;
//using Topshelf;
using WinStash.Core.config;
using Newtonsoft.Json;
using WinStash.Core;
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

            

            // get folder with plugins 
            var folder = AppDomain.CurrentDomain.BaseDirectory;
            var availablePlugins = new DirectoryInfo($"{folder}\\plugins");


            List<Type> inmplementedTypes = null;

            List<PluginDescriptor> descriptors = new List<PluginDescriptor>();


            foreach (FileInfo fileInfo in availablePlugins.GetFiles("input.*.dll", SearchOption.AllDirectories))
            {
                var singleAssembly = Assembly.LoadFile(fileInfo.FullName);
                var classType =
                    singleAssembly.GetTypes()
                        .FirstOrDefault(p => typeof (IInputPlugin).IsAssignableFrom(p) && p.IsClass);

                PluginDescriptor myvar = new PluginDescriptor()
                {
                    implementedType = classType,
                    pluginMeta = MetadataHelper.GetMetadata(classType)
                };

                
                
                descriptors.Add(myvar);

                builder.RegisterAssemblyTypes(singleAssembly);
            }

            //// build our container with dependencies
            var container = builder.Build();

            //// Test resolving of components 
            var scope = container.BeginLifetimeScope();

            IInputPlugin cc = scope.ResolveNamed<IInputPlugin>(descriptors[0].pluginMeta.FirstOrDefault(k => k.Key == "Name").Value.ToString());

            //var ssss = descriptors[0].implementedType;



            //var instance = (IInputPlugin) container.Resolve();

            // Here we  should get test information now 
            Console.WriteLine( cc.QueryForData() );








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

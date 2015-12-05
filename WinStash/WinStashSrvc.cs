using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Plugin.Input.WinEvent;
using WinStash.Core.Plugins;

namespace WinStash
{
    public class WinStashSrvc
    {

        private Timer _timer;
        private IContainer _container;

        public WinStashSrvc(IContainer cnt)
        {
            _container = cnt;
        }

        /// <summary>
        /// Method executed on start of service
        /// </summary>
        public void Start()
        {
             // Initialise new timer with callback to method and timespan of 5 seconds
            _timer = new Timer(new TimerCallback(tmr_callback),null,0,5000);
        }

        /// <summary>
        /// Method which is executed as callback to our timer ( interval )
        /// </summary>
        /// <param name="state"></param>
        private void tmr_callback(object state)
        {
            // Create scope for this execution
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IInputPlugin>();

                var resultos = service.QueryForData();

                //TODO: Debug part - remove when ready
                Console.WriteLine($"EVT : count is {resultos.Count}");

            }
            
            //TODO: Debug part - remove when ready ? Or build in debug switch?
            Console.WriteLine($"EVT : Now executed : {DateTime.Now.ToUniversalTime().ToString("O")}");

        }

        /// <summary>
        /// Method which is executed to stop our service
        /// </summary>
        public void Stop()
        {
            _timer.Dispose();
        }
    }
}

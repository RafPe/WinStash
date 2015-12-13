using System;
using System.Threading;
using Autofac;
using Plugin.Input.WinEvent;
using WinStash.Core.plugins;

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

            _timer.Change(Timeout.Infinite, Timeout.Infinite);

            // Create scope for this execution
            using (var scope = _container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IInputPlugin>();

                var srvc2 = scope.Resolve<IWinEventPlugin>();

                var resultos = service.QueryForData();

                //TODO: Debug part - remove when ready
                Console.WriteLine($"EVT : count is {resultos.Count}");


            }
            
            //TODO: Debug part - remove when ready ? Or build in debug switch?
            Console.WriteLine($"EVT : Now executed : {DateTime.Now.ToUniversalTime().ToString("O")}");


            _timer.Change(5000, 5000);
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

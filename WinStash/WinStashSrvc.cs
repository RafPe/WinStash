using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinStash
{
    public class WinStashSrvc
    {

        private Timer _timer;

        public WinStashSrvc()
        {
            
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
                Console.WriteLine($"Now executed : {DateTime.Now.ToUniversalTime().ToString("O")}");

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

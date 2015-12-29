using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinStash.Core.plugins
{
    public class PluginTask
    {
        public string                       key                         { get; set; }

        readonly CancellationTokenSource    _cancellationTokenSource;
        readonly CancellationToken          _cancellationToken;
        readonly Task                       _task;

        public PluginTask()
        {
            _cancellationTokenSource    = new CancellationTokenSource();
            _cancellationToken          = _cancellationTokenSource.Token;

            _task = new Task(delegate {  }, _cancellationToken);
        }
    }
}

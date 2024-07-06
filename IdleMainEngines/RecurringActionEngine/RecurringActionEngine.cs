using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleMainEngine.RecurringActionEngine
{
    public class RecurringActionEngine
    {
        private readonly TimeSpan _interval;
        private readonly CancellationToken _cancellationToken;

        public RecurringActionEngine(TimeSpan interval, CancellationToken cancellationToken)
        {
            _interval = interval;
            _cancellationToken = cancellationToken;
        }

        public async Task StartAsync()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                await PerformActionAsync();
                await Task.Delay(_interval, _cancellationToken);
            }
        }

        private Task PerformActionAsync()
        {
            return Task.Run(() =>
            {
                // Action récurrente
                Console.WriteLine($"Action performed at {DateTime.Now}");
            }, _cancellationToken);
        }
    }
}

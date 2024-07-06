using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleMainEngine.RecurringActionEngine
{
    public class Dispatcher
    {
        private readonly BlockingCollection<Func<Task>> _taskQueue = new();
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public void Start()
        {
            Task.Factory.StartNew(async () =>
            {
                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (_taskQueue.TryTake(out var taskFunc))
                    {
                        await taskFunc();
                    }
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        public void AddTask(Func<Task> taskFunc)
        {
            _taskQueue.Add(taskFunc);
        }

        public CancellationToken CancellationToken => _cancellationTokenSource.Token;
    }
}

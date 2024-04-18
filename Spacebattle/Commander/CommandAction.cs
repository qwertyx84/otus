using Commander.Interfaces;
namespace Commander.Actions
{
    /// <summary>
    // Команда для выполнения кода в отдельном потоке
    /// </summary>
    public class StartCommand : ICommand
    {
        private readonly Action action;

        public StartCommand(Action action)
        {
            this.action = action;
        }

        public void Execute()
        {
            Thread thread = new Thread(() => action());
            thread.Start();
        }
    }
    /// <summary>
    // Команда для остановки выполнения кода в отдельном потоке после завершения всех команд (soft stop)
    /// </summary>
    class SoftStopCommand : ICommand
    {
        private readonly Thread executionThread;
        private readonly CancellationTokenSource cancellationTokenSource;

        public SoftStopCommand(Thread executionThread, CancellationTokenSource cancellationTokenSource)
        {
            this.executionThread = executionThread;
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public void Execute()
        {
            
            cancellationTokenSource.Cancel();
            Console.WriteLine("Execution SoftStopCommand");
        }
    }
}

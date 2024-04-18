using System.Collections.Concurrent;
using Commander.Interfaces;
using Commander.Actions;
using System.Threading;
namespace Commander
{
    /// <summary>
    // Класс для обработки и управления командами
    /// </summary>
    public class CommandExecutor
    {
        public readonly ConcurrentQueue<ICommand> commandQueue = new ConcurrentQueue<ICommand>();
        private readonly CancellationTokenSource cts = new CancellationTokenSource();

        public Thread executionThread { get; }

        /// <summary>
        // Конструктор класса
        /// </summary>
        public CommandExecutor(Boolean startExecute = true)
        {
            executionThread = new Thread(ExecuteCommands);
            if (startExecute)
                StartExecute();
        }
        public void StartExecute()
        {
            executionThread.Start();
        }

        public void EnqueueCommand(ICommand command)
        {
            commandQueue.Enqueue(command);
        }
        /// <summary>
        // Метод для выполнения команд из очереди
        /// </summary>
        private void ExecuteCommands()
        {
            while (!cts.IsCancellationRequested)// && !ctsHard.IsCancellationRequested)
            {

                while (commandQueue.TryDequeue(out ICommand command) && !cts.IsCancellationRequested)
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error executing command: {ex.Message}");
                    }
                }
                Thread.Sleep(100); // Если очередь пуста, ждем некоторое время перед проверкой снова
            }

        }
        /// <summary>
        // Остановка выполнения очереди команд дожидаясь полного завершения уже имеющихся (soft stop)
        /// </summary>
        public void StopExecutionSoft()
        {
            EnqueueCommand(new SoftStopCommand(executionThread, cts));
        }
        /// <summary>
        // Остановка выполнения очереди команд не дожидаясь их полного завершения (hard stop)
        /// </summary>
        public void StopExecutionHard()
        {
            cts.Cancel();
            Console.WriteLine("Execution HardStopCommand");
        }

}
}

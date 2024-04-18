using Commander;
using Commander.Actions;
using Commander.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        CommandExecutor executor = new();

        
        for (int i = 1; i <= 10; i++)
        {
            executor.EnqueueCommand(new TestCommand($"TestCommand {i}"));
        }
        Thread.Sleep(1000); // Дадим потокам время для выполнения

        // Остановка выполнения команд Soft stop
        //executor.StopExecutionSoft();

        // Остановка выполнения команд Hard stop
         executor.StopExecutionHard();

        executor.EnqueueCommand(new StartCommand(() => Console.WriteLine("TestCommand After Stop")));

    }
    /// <summary>
    // Класс от интерфейса ICommand для тестирования с выводом сообщения в консоль и задержкой
    /// </summary>
    public class TestCommand : ICommand
    {
        private string _message;

        public TestCommand(string message)
        {
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine(_message);
            Thread.Sleep(200);
        }
    }

}
using Commander;
using ICommand = Commander.Interfaces.ICommand;

namespace CommanderTests
{
    public class UnitTestRun
    {
        /// <summary>
        // Тест, который проверяет, что после команды старт поток запущен
        /// </summary>
        [Fact]
        public void CommandExecutor_StartThread()
        {
 
            CommandExecutor executor = new(false);
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            executor.StartExecute();
            Thread.Sleep(1000); 
            Assert.True(executor.executionThread.ThreadState == ThreadState.Running || executor.executionThread.ThreadState == ThreadState.WaitSleepJoin);

            executor.StopExecutionSoft();
        }
        /// <summary>
        // Тест, который проверяет, что после команды soft stop, поток завершается только после того, как все задачи закончились
        /// </summary>
        [Fact]
        public void CommandExecutor_StartThreadAndStopSoft()
        {
            CommandExecutor executor = new();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            Thread.Sleep(1000); 
            executor.StopExecutionSoft();
            executor.executionThread.Join();
            //Assert
            Assert.True(executor.executionThread.ThreadState == ThreadState.Stopped);
            Assert.Empty(executor.commandQueue);
           
        }
        /// <summary>
        // Тест, который проверяет, что после команды hard stop, поток завершается
        /// </summary>
        [Fact]
        public void CommandExecutor_StartThreadAndStopHard()
        {
            CommandExecutor executor = new();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            Thread.Sleep(1000); 
            executor.StopExecutionHard();
            executor.executionThread.Join();

            //Assert
            Assert.True(executor.executionThread.ThreadState == ThreadState.Stopped);
            Assert.NotEmpty(executor.commandQueue);

        }

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
using Commander;
using ICommand = Commander.Interfaces.ICommand;

namespace CommanderTests
{
    public class UnitTestRun
    {

        [Fact]
        public void CommandExecutor_StartThread()
        {
 
            CommandExecutor executor = new();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            Thread.Sleep(1000); // Дадим потокам время для выполнения
            Assert.True(executor.executionThread.ThreadState == ThreadState.Running || executor.executionThread.ThreadState == ThreadState.WaitSleepJoin);

            executor.StopExecutionSoft();
        }
        [Fact]
        public void CommandExecutor_StartThreadAndStopSoft()
        {
            CommandExecutor executor = new();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            Thread.Sleep(1000); // Дадим потокам время для выполнения
            executor.StopExecutionSoft();
            executor.executionThread.Join();
            //Assert
            Assert.True(executor.executionThread.ThreadState == ThreadState.Stopped);
            Assert.Empty(executor.commandQueue);

            
        }

        [Fact]
        public void CommandExecutor_StartThreadAndStopHard()
        {
            CommandExecutor executor = new();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Test command {i}"));
            }
            Thread.Sleep(1000); // Дадим потокам время для выполнения
            executor.StopExecutionSoft();
            for (int i = 1; i <= 10; i++)
            {
                executor.EnqueueCommand(new TestCommand($"Next test command {i}"));
            }
            executor.executionThread.Join();

            //Assert
            Assert.True(executor.executionThread.ThreadState == ThreadState.Stopped);
            Assert.NotEmpty(executor.commandQueue);


        }

    }



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
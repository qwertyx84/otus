class Program
{
    static async Task Main(string[] args)
    {
        // Создаем команды
        var lastCommand = new lastCommand();
        var command3 = new Command3(lastCommand); 
        var command2 = new Command2(command3);
        var command1 = new Command1(command2);

        // Запускаем цепочку команд
        await command1.ExecuteAsync();
    }
}

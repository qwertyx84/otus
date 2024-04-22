using SpaceBattle.Interfaces;
using System;
using System.Threading.Tasks;


/// <summary>
// Команда 1 от интерфейса ICommand 
/// </summary>
class Command1 : ICommand
{
    ICommand _next;
    public Command1(ICommand next) => _next = next;
    public async Task ExecuteAsync()
    {
        await _next.ExecuteAsync();
        Console.WriteLine("Команда1");
    }
}

/// <summary>
// Команда 2 от интерфейса ICommand 
/// </summary>
class Command2 : ICommand
{
    ICommand _next;
    public Command2(ICommand next) => _next = next;

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Команда2");
        if (_next != null)
            await _next.ExecuteAsync();
    }
}

/// <summary>
// Команда 3 от интерфейса ICommand 
/// </summary>
class Command3 : ICommand
{
    ICommand _next;
    public Command3(ICommand next) => _next = next;

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Команда3");
        if (_next != null)
            await _next.ExecuteAsync();
    }
}

/// <summary>
// Команда-заглушка от интерфейса ICommand 
/// </summary>
class lastCommand : ICommand
{
    public async Task ExecuteAsync()
    {
        // Ничего не делаем
    }
}

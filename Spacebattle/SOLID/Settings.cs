/// <summary>
/// Класс Settings реализует интерфейс ISettings и хранит настройки игры.
/// </summary>
namespace SOLID.GameSettings
{
    public class Settings : ISettings
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int MaxAttempts { get; set; }
    }
}
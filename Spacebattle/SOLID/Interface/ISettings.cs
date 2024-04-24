/// <summary>
/// Интерфейс ISettings определяет контракт для классов, хранящих настройки игры.
/// </summary>
public interface ISettings
{
    int MinValue { get; }
    int MaxValue { get; }
    int MaxAttempts { get; }
}
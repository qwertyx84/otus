/// <summary>
/// Интерфейс IPlayer определяет контракт для классов, представляющих игрока.
/// </summary>
public interface IPlayer
{
    int GetGuess();
    void InitName();
    string GetName();
}
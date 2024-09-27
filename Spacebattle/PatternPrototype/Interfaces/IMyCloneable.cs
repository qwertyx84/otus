/// <summary>
/// Интерфейс IMyCloneable
/// <summary>
public interface IMyCloneable<out T>
{
    T Clone();
}

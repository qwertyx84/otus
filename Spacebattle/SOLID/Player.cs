/// <summary>
/// Класс Player реализует интерфейс IPlayer и представляет игрока.
/// </summary>
namespace SOLID.GamePlayer
{
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public Player()
        {
            InitName();
        }

        public void InitName()
        {
            Console.Write("Введите ваше имя: ");
            Name = Console.ReadLine();

        }
        public string GetName() { return Name; }

        public int GetGuess()
        {
            Console.Write("Введите число: ");
            var input = Console.ReadLine();
            return int.Parse(input);
        }
    }
}
using SOLID.GamePlayer;

/// <summary>
/// Класс Game реализует интерфейс IGame и отвечает за игровую логику.
/// </summary>
namespace SOLID.GameLogic
{
    public class Game : IGame
    {
        private readonly ISettings _settings;
        private readonly IPlayer _player;

        public Game(ISettings settings, IPlayer player)
        {
            _settings = settings;
            _player = player;
        }

        public bool Start()
        {
            int attempts = 0;
            var numberToGuess = GenerateRandomNumber();
            Console.WriteLine($"{_player.GetName()}, давайте сыграем в игру! Я загадал число от {_settings.MinValue} до {_settings.MaxValue}. Угадай число, у вас {_settings.MaxAttempts} попыток!");
            while (attempts < _settings.MaxAttempts)
            {
                var guess = _player.GetGuess();

                if (guess == numberToGuess)
                {
                    Console.WriteLine($"{_player.GetName()}, вы угадали!");
                    return true;
                }
                else if (guess < numberToGuess)
                {
                    Console.WriteLine("Больше");
                }
                else
                {
                    Console.WriteLine("Меньше");
                }

                attempts++;
            }

            Console.WriteLine($"{_player.GetName()}б вы не угадали");
            return false;
        }

        private int GenerateRandomNumber()
        {
            var random = new Random();
            return random.Next(_settings.MinValue, _settings.MaxValue + 1);
        }
    }
}
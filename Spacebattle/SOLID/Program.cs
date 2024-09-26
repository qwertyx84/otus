﻿
using SOLID.GameLogic;
using SOLID.GamePlayer;
using SOLID.GameSettings;

internal class Program
{
    /// <summary>
    ///  SOLID - Single responsibility(SRP), Open-closed(OCP), Liskov substitution(LSP), Interface segregation(ISP) и Dependency inversion(DIP)
    ///  
    /// Принцип единственной ответственности (SRP)
    /// Разбиваем класс на несколько классов, каждый из которых отвечает за свою конкретную задачу.

    /// Принцип инверсии зависимостей (DIP)
    /// Класс Game не создает экземпляры классов Settings и Player напрямую.
    /// Вместо этого он принимает объекты этих классов в качестве конструктора.
    /// Это позволяет использовать различные реализации классов Settings и Player, например, для тестирования или для поддержки разных типов игроков.

    /// Принцип разделения интерфейса (ISP)
    /// Классы Settings и Player не реализуют никаких методов, которые не определены в соответствующих им интерфейсах.
    /// Это гарантирует, что клиенты не будут зависеть от методов, которые им не нужны.

    ///Принцип открытости/закрытости (OCP)
    ///Классы Game, Settings и Player открыты для расширения - вы можете создавать новые реализации этих классов, не изменяя существующий код. Например, вы можете создать новый класс Player с другим способом получения имени игрока.
    ///Существующие классы закрыты для изменения - вам не нужно изменять существующий код, когда вы создаете новые реализации классов. Например, если вы создадите новый класс Player, вам не нужно будет изменять код класса Game.

    /// Принцип подстановки Барбары Лисков (LSP)
    /// Классы Settings и Player реализуют соответствующие им интерфейсы, гарантируя, что они будут вести себя как любые другие классы, реализующие эти интерфейсы.
    /// Это позволяет легко создавать новые реализации этих классов, не изменяя существующий код.
    /// </summary>
    private static void Main(string[] args)
    {
        var settings = new Settings
        {
            MinValue = 1,
            MaxValue = 20,
            MaxAttempts = 10
        };

        var player = new Player();


        var game = new Game(settings, player);
        game.Start();
    }
}
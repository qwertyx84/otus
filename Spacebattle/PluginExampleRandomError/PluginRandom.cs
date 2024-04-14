using PluginInterfaces;
using System.Transactions;

namespace PluginExampleRandomError

{
    /// <summary>
    /// Правильный плагин
    /// </summary>
    
    public class PluginRnd_ErrorOver_80_Percent : IPlugin
    {
        public void Load()
        {
            var rnd = new Random().Next(100);
            if (rnd > 80)
                throw new Exception($"Плагин \"{this.GetType().Name}\" вызвал ошибку, rnd = {rnd}");

            Console.WriteLine($"{this.GetType().Name} загружен, rnd = {rnd}");
        }

    }
    public class PluginRnd_ErrorOver_70_Percent : IPlugin
    {
        public void Load()
        {
            var rnd = new Random().Next(100);
            if (rnd > 70)
                throw new Exception($"Плагин \"{this.GetType().Name}\" вызвал ошибку, rnd = {rnd}");

            Console.WriteLine($"{this.GetType().Name} загружен, rnd = {rnd}");
        }

    }
    public class PluginRnd_ErrorOver_60_Percent : IPlugin
    {
        public void Load()
        {
            var rnd = new Random().Next(100);
            if (rnd > 60)
                throw new Exception($"Плагин \"{this.GetType().Name}\" вызвал ошибку, rnd = {rnd}");

            Console.WriteLine($"{this.GetType().Name} загружен, rnd = {rnd}");
        }

    }
    public class PluginRnd_ErrorOver_50_Percent : IPlugin
    {
        public void Load()
        {
            var rnd = new Random().Next(100);
            if (rnd > 50)
                throw new Exception($"Плагин \"{this.GetType().Name}\" вызвал ошибку, rnd = {rnd}");

            Console.WriteLine($"{this.GetType().Name} загружен, rnd = {rnd}");
        }

    }

}

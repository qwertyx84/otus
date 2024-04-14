using PluginInterfaces;

namespace PluginExampleOk
{
    /// <summary>
    /// Правильный плагин
    /// </summary>
    public class PluginOk : IPlugin
    {
        public void Load()
        {
            Thread.Sleep(1000);
            Console.WriteLine($"{this.GetType().Name} загружен.");
        }
       
    }
}

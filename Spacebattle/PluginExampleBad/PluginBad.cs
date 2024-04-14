
namespace PluginExampleBad
{
    /// <summary>
    /// Неправильный плагин
    /// </summary>
    public class PluginBad 
    {
        public void Load()
        {
            Console.WriteLine($"{this.GetType().Name} загружен.");
        }
    }


}

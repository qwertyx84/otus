
namespace PluginExampleBad
{
    /// <summary>
    /// Неправильный плагин, не наследован от необходимого интерфейса
    /// </summary>
    public class PluginBad 
    {
        public void Load()
        {
            Console.WriteLine($"{this.GetType().Name} загружен.");
        }
    }


}

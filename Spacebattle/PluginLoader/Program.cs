
using System.Collections.Concurrent;
using System.Reflection;

namespace PluginLoader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string pluginDirectory = "C:\\temp\\plugins";
            Console.WriteLine($"Скопируйте файлы плагинов в каталог {pluginDirectory} и нажмите любую клавишу для загрузки плагинов");
            Console.ReadLine();

            PluginLoader pluginLoader = new PluginLoader(pluginDirectory);

            Thread scanThread = new Thread(pluginLoader.ScanPlugins);
            Thread loadThread = new Thread(pluginLoader.LoadPlugins);

            Console.WriteLine($"Старт загрузки плагинов.");
            scanThread.Start();
            loadThread.Start();

            scanThread.Join();
            loadThread.Join();

            Console.WriteLine("Загрузка плагинов завершена");
            pluginLoader.WriteResult();
            Console.ReadLine();
        }
    }
}
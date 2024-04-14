using System.Collections.Concurrent;
using System.Reflection;
using PluginInterfaces;

namespace PluginLoader
{
    internal class PluginLoader
    {
        public int countIPlugins;
        public int countIPluginsLoaded;
        public void WriteResult()
        {
            if (countIPlugins == countIPluginsLoaded)
                Console.WriteLine($"Обнаружено и успешно загружено {countIPlugins} плагинов наследованных от необходимого интерфейса");
            else
                Console.WriteLine($"Обнаружено {countIPlugins} плагинов наследованных от необходимого интерфейса, из них уcпешно загружено {countIPluginsLoaded}. Ошибка в системе плагинов!");

        }

        private readonly string pluginDirectory;
        private ConcurrentQueue<IPlugin> pluginQueue = new ConcurrentQueue<IPlugin>();
        private Boolean ScanPluginsEnd = false;

        public PluginLoader(string pluginDirectory)
        {
            this.pluginDirectory = pluginDirectory;
        }

        public void ScanPlugins()
        {
            if (!Directory.Exists(pluginDirectory))
                throw new Exception($"Не найден каталог загрузки плагина {pluginDirectory}"); 

            var files = Directory.GetFiles(pluginDirectory, "*.dll");

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t));

                if (types.Count()==0)
                    Console.WriteLine($"Плагин в {file} не наследован от необходимого интерфейса и будет пропущен");
                else
                    foreach (var type in types)
                    {
                        Thread.Sleep(1000);
                        IPlugin pluginInstance = Activator.CreateInstance(type) as IPlugin;
                        pluginQueue.Enqueue(pluginInstance);
                        Console.WriteLine($"Плагин {pluginInstance.GetType().Name} помещен в очередь");
                        countIPlugins++;
                    }
            }
            ScanPluginsEnd = true;
        }

        public void LoadPlugins()
        {
            var pluginQueueNextTry = new ConcurrentQueue<IPlugin>();
            IPlugin plugin;
            var countQueue = pluginQueue.Count;

            while (!pluginQueue.IsEmpty || !ScanPluginsEnd)
            {
                if (pluginQueue.TryDequeue(out plugin))
                {
                    try
                    {
                        Thread.Sleep(1000);
                        plugin.Load();
                        countIPluginsLoaded++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка загрузки плагина : {ex.Message}");
                        pluginQueueNextTry.Enqueue(plugin); 
                    }
                }
            }
            if (countQueue != pluginQueueNextTry.Count)
            {
                pluginQueue = pluginQueueNextTry;
                LoadPlugins();
            }


        }
    }
}

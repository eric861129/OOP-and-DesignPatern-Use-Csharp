using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 系統設定管理器，採用單例模式確保整個應用程式只有一個實例
    /// </summary>
    public sealed class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();

        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        public string ConnectionString { get; private set; }

        // 私人建構式避免外部建立物件
        private ConfigurationManager()
        {
            Console.WriteLine("建立 ConfigurationManager 唯一實例");
            // 模擬載入設定資料
            ConnectionString = "Server=myServer;Database=myDB;User Id=myUser;";
        }

        /// <summary>
        /// 取得唯一的 ConfigurationManager 實例
        /// </summary>
        public static ConfigurationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigurationManager();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    /// <summary>
    /// 示範如何使用 Singleton 的主程式
    /// </summary>
    public static class SingletonDemo
    {
        public static void Main()
        {
            // 第一次呼叫建立實例
            ConfigurationManager config1 = ConfigurationManager.Instance;

            // 第二次呼叫取得同一個實例
            ConfigurationManager config2 = ConfigurationManager.Instance;

            if (config1 == config2)
            {
                Console.WriteLine("確認過眼神，是同一個 Singleton 實例！");
                Console.WriteLine("設定資料庫連線字串為：" + config1.ConnectionString);
            }
        }
    }
}

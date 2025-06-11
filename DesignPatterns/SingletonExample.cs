using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 簡易日誌紀錄器，採用單例模式確保只有一個實例
    /// </summary>
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        /// <summary>
        /// 取得唯一的 Logger 實例
        /// </summary>
        public static Logger Instance => _instance.Value;

        // 私人建構式避免外部實例化
        private Logger() { }

        /// <summary>
        /// 紀錄訊息
        /// </summary>
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}");
        }
    }

    /// <summary>
    /// Singleton 範例程式
    /// </summary>
    public static class SingletonProgram
    {
        public static void Main()
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            Console.WriteLine(object.ReferenceEquals(logger1, logger2));
            logger1.Log("系統啟動");
        }
    }
}

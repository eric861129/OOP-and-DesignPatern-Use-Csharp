using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 歐洲規格的插座
    /// </summary>
    public class EuropeanSocket
    {
        /// <summary>
        /// 歐洲插座專用的插電方法
        /// </summary>
        public void SpecificRequest() => Console.WriteLine("使用歐洲規格的插座");
    }

    /// <summary>
    /// 台灣插頭介面
    /// </summary>
    public interface ITaiwanPlug
    {
        /// <summary>
        /// 插電請求
        /// </summary>
        void Request();
    }

    /// <summary>
    /// 介面卡：讓歐洲插座可以使用台灣插頭
    /// </summary>
    public class PlugAdapter : ITaiwanPlug
    {
        private readonly EuropeanSocket _europeanSocket;

        /// <summary>
        /// 建立介面卡並指定要轉接的歐洲插座
        /// </summary>
        /// <param name="socket">欲轉接的歐洲插座</param>
        public PlugAdapter(EuropeanSocket socket)
        {
            _europeanSocket = socket;
        }

        /// <summary>
        /// 轉接後的插電動作
        /// </summary>
        public void Request()
        {
            // 先呼叫歐洲插座的插電方式
            _europeanSocket.SpecificRequest();
            Console.WriteLine("透過介面卡轉接，順利連接到台灣插頭。");
        }
    }

    /// <summary>
    /// 示範如何使用介面卡模式
    /// </summary>
    public static class AdapterDemo
    {
        public static void Main()
        {
            // 建立歐洲插座
            EuropeanSocket europeanSocket = new EuropeanSocket();

            // 使用介面卡連接台灣插頭
            ITaiwanPlug adapter = new PlugAdapter(europeanSocket);
            adapter.Request();
        }
    }
}

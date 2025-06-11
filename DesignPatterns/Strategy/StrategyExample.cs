using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 旅遊交通策略介面
    /// </summary>
    public interface ITravelStrategy
    {
        /// <summary>
        /// 前往指定目的地
        /// </summary>
        /// <param name="destination">目的地名稱</param>
        void Travel(string destination);
    }

    /// <summary>
    /// 搭乘飛機的策略
    /// </summary>
    public class PlaneStrategy : ITravelStrategy
    {
        /// <inheritdoc />
        public void Travel(string destination)
        {
            Console.WriteLine($"搭飛機前往 {destination}");
        }
    }

    /// <summary>
    /// 搭乘高鐵的策略
    /// </summary>
    public class HighSpeedRailStrategy : ITravelStrategy
    {
        /// <inheritdoc />
        public void Travel(string destination)
        {
            Console.WriteLine($"搭高鐵前往 {destination}");
        }
    }

    /// <summary>
    /// 開車的策略
    /// </summary>
    public class CarStrategy : ITravelStrategy
    {
        /// <inheritdoc />
        public void Travel(string destination)
        {
            Console.WriteLine($"開車前往 {destination}");
        }
    }

    /// <summary>
    /// 旅客，根據不同策略選擇交通方式
    /// </summary>
    public class Traveler
    {
        private ITravelStrategy? _travelStrategy;

        /// <summary>
        /// 設定旅遊策略
        /// </summary>
        /// <param name="strategy">交通策略</param>
        public void SetStrategy(ITravelStrategy strategy)
        {
            _travelStrategy = strategy;
        }

        /// <summary>
        /// 前往指定目的地
        /// </summary>
        /// <param name="destination">目的地</param>
        public void TravelTo(string destination)
        {
            _travelStrategy?.Travel(destination);
        }
    }

    /// <summary>
    /// 策略模式範例主程式
    /// </summary>
    public static class StrategyDemo
    {
        public static void Main()
        {
            Traveler traveler = new Traveler();

            traveler.SetStrategy(new PlaneStrategy());
            traveler.TravelTo("東京");

            traveler.SetStrategy(new HighSpeedRailStrategy());
            traveler.TravelTo("台南");

            traveler.SetStrategy(new CarStrategy());
            traveler.TravelTo("宜蘭");
        }
    }
}

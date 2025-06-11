using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 披薩產品介面
    /// </summary>
    public interface IPizza
    {
        /// <summary>
        /// 準備披薩所需的食材
        /// </summary>
        void Prepare();

        /// <summary>
        /// 烘烤披薩
        /// </summary>
        void Bake();

        /// <summary>
        /// 切割披薩
        /// </summary>
        void Cut();

        /// <summary>
        /// 披薩裝盒
        /// </summary>
        void Box();
    }

    /// <summary>
    /// 起司披薩
    /// </summary>
    public class CheesePizza : IPizza
    {
        public void Prepare() => Console.WriteLine("準備起司披薩的食材");
        public void Bake() => Console.WriteLine("烤製起司披薩中");
        public void Cut() => Console.WriteLine("切割起司披薩");
        public void Box() => Console.WriteLine("起司披薩裝盒完成");
    }

    /// <summary>
    /// 海鮮披薩
    /// </summary>
    public class SeafoodPizza : IPizza
    {
        public void Prepare() => Console.WriteLine("準備海鮮披薩的食材");
        public void Bake() => Console.WriteLine("烤製海鮮披薩中");
        public void Cut() => Console.WriteLine("切割海鮮披薩");
        public void Box() => Console.WriteLine("海鮮披薩裝盒完成");
    }

    /// <summary>
    /// 披薩工廠介面
    /// </summary>
    public interface IPizzaFactory
    {
        /// <summary>
        /// 建立披薩
        /// </summary>
        IPizza CreatePizza();
    }

    /// <summary>
    /// 起司披薩工廠
    /// </summary>
    public class CheesePizzaFactory : IPizzaFactory
    {
        public IPizza CreatePizza() => new CheesePizza();
    }

    /// <summary>
    /// 海鮮披薩工廠
    /// </summary>
    public class SeafoodPizzaFactory : IPizzaFactory
    {
        public IPizza CreatePizza() => new SeafoodPizza();
    }

    /// <summary>
    /// 示範如何使用工廠方法模式
    /// </summary>
    public static class FactoryMethodDemo
    {
        public static void Main()
        {
            // 顧客點了一個起司披薩
            IPizzaFactory cheeseFactory = new CheesePizzaFactory();
            IPizza cheesePizza = cheeseFactory.CreatePizza();
            cheesePizza.Prepare();
            cheesePizza.Bake();
            cheesePizza.Cut();
            cheesePizza.Box();

            Console.WriteLine();

            // 顧客點了一個海鮮披薩
            IPizzaFactory seafoodFactory = new SeafoodPizzaFactory();
            IPizza seafoodPizza = seafoodFactory.CreatePizza();
            seafoodPizza.Prepare();
            seafoodPizza.Bake();
            seafoodPizza.Cut();
            seafoodPizza.Box();
        }
    }
}

using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 咖啡抽象元件
    /// </summary>
    public abstract class Coffee
    {
        /// <summary>
        /// 取得描述文字
        /// </summary>
        /// <returns>咖啡內容描述</returns>
        public abstract string GetDescription();

        /// <summary>
        /// 取得售價
        /// </summary>
        /// <returns>價格</returns>
        public abstract double GetCost();
    }

    /// <summary>
    /// 基本咖啡，不額外加料
    /// </summary>
    public class SimpleCoffee : Coffee
    {
        public override string GetDescription() => "基本咖啡";

        public override double GetCost() => 50;
    }

    /// <summary>
    /// 裝飾者基底類別
    /// </summary>
    public abstract class CoffeeDecorator : Coffee
    {
        protected readonly Coffee _coffee;

        /// <summary>
        /// 傳入要裝飾的咖啡
        /// </summary>
        /// <param name="coffee">原始咖啡</param>
        protected CoffeeDecorator(Coffee coffee)
        {
            _coffee = coffee;
        }
    }

    /// <summary>
    /// 牛奶裝飾者
    /// </summary>
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(Coffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + " + 牛奶";

        public override double GetCost() => _coffee.GetCost() + 10;
    }

    /// <summary>
    /// 糖漿裝飾者
    /// </summary>
    public class SyrupDecorator : CoffeeDecorator
    {
        public SyrupDecorator(Coffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + " + 糖漿";

        public override double GetCost() => _coffee.GetCost() + 5;
    }

    /// <summary>
    /// 裝飾者模式示範
    /// </summary>
    public static class DecoratorDemo
    {
        public static void Main()
        {
            Coffee coffee = new SimpleCoffee();
            // 加牛奶
            coffee = new MilkDecorator(coffee);
            // 再加糖漿
            coffee = new SyrupDecorator(coffee);

            Console.WriteLine(coffee.GetDescription());
            Console.WriteLine($"總價格：{coffee.GetCost()} 元");
        }
    }
}

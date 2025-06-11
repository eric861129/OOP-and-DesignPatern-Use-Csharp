using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 三明治產品
    /// </summary>
    public class Sandwich
    {
        /// <summary>
        /// 麵包種類
        /// </summary>
        public string Bread { get; set; }

        /// <summary>
        /// 起司種類
        /// </summary>
        public string Cheese { get; set; }

        /// <summary>
        /// 蔬菜配料
        /// </summary>
        public List<string> Veggies { get; set; } = new List<string>();

        /// <summary>
        /// 醬料
        /// </summary>
        public string Sauce { get; set; }

        /// <summary>
        /// 顯示三明治內容
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"三明治配料：麵包({Bread})、起司({Cheese})、蔬菜({string.Join(", ", Veggies)})、醬料({Sauce})");
        }
    }

    /// <summary>
    /// 三明治建造者介面
    /// </summary>
    public interface ISandwichBuilder
    {
        /// <summary>
        /// 選擇麵包
        /// </summary>
        void AddBread();

        /// <summary>
        /// 加入起司
        /// </summary>
        void AddCheese();

        /// <summary>
        /// 加入蔬菜
        /// </summary>
        void AddVeggies();

        /// <summary>
        /// 加入醬料
        /// </summary>
        void AddSauce();

        /// <summary>
        /// 取得完成的三明治
        /// </summary>
        Sandwich GetSandwich();
    }

    /// <summary>
    /// 義大利風三明治建造者
    /// </summary>
    public class ItalianSandwichBuilder : ISandwichBuilder
    {
        private readonly Sandwich _sandwich = new Sandwich();

        public void AddBread() => _sandwich.Bread = "義大利麵包";
        public void AddCheese() => _sandwich.Cheese = "莫札瑞拉起司";
        public void AddVeggies() => _sandwich.Veggies.AddRange(new[] { "番茄", "羅勒", "洋蔥" });
        public void AddSauce() => _sandwich.Sauce = "義式醬料";
        public Sandwich GetSandwich() => _sandwich;
    }

    /// <summary>
    /// 素食三明治建造者
    /// </summary>
    public class VeggieSandwichBuilder : ISandwichBuilder
    {
        private readonly Sandwich _sandwich = new Sandwich();

        public void AddBread() => _sandwich.Bread = "全麥麵包";
        public void AddCheese() => _sandwich.Cheese = "素食起司";
        public void AddVeggies() => _sandwich.Veggies.AddRange(new[] { "生菜", "番茄", "小黃瓜" });
        public void AddSauce() => _sandwich.Sauce = "蜂蜜芥末醬";
        public Sandwich GetSandwich() => _sandwich;
    }

    /// <summary>
    /// 指揮者，負責控制建造流程
    /// </summary>
    public class SandwichDirector
    {
        /// <summary>
        /// 建構三明治
        /// </summary>
        /// <param name="builder">具體建造者</param>
        public Sandwich Construct(ISandwichBuilder builder)
        {
            builder.AddBread();
            builder.AddCheese();
            builder.AddVeggies();
            builder.AddSauce();
            return builder.GetSandwich();
        }
    }

    /// <summary>
    /// 示範建造者模式的主程式
    /// </summary>
    public static class BuilderDemo
    {
        public static void Main()
        {
            var director = new SandwichDirector();

            // 製作義大利風三明治
            ISandwichBuilder italianBuilder = new ItalianSandwichBuilder();
            Sandwich italianSandwich = director.Construct(italianBuilder);
            italianSandwich.Display();

            Console.WriteLine();

            // 製作素食三明治
            ISandwichBuilder veggieBuilder = new VeggieSandwichBuilder();
            Sandwich veggieSandwich = director.Construct(veggieBuilder);
            veggieSandwich.Display();
        }
    }
}

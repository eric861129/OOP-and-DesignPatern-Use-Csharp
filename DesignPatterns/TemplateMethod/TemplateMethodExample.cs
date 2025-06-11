using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 披薩製作流程的抽象類別，定義固定步驟
    /// </summary>
    public abstract class PizzaMaker
    {
        /// <summary>
        /// 製作披薩的模板方法，固定流程順序
        /// </summary>
        public void MakePizza()
        {
            PrepareDough();
            AddSauce();
            AddToppings();
            BakePizza();
        }

        /// <summary>
        /// 準備麵團
        /// </summary>
        protected void PrepareDough()
        {
            Console.WriteLine("揉製麵團...");
        }

        /// <summary>
        /// 加入醬料
        /// </summary>
        protected void AddSauce()
        {
            Console.WriteLine("加入醬料...");
        }

        /// <summary>
        /// 加入配料，由子類別實作
        /// </summary>
        protected abstract void AddToppings();

        /// <summary>
        /// 烘烤披薩
        /// </summary>
        protected void BakePizza()
        {
            Console.WriteLine("烤製披薩...");
        }
    }

    /// <summary>
    /// 夏威夷披薩的製作流程
    /// </summary>
    public class HawaiianPizzaMaker : PizzaMaker
    {
        /// <inheritdoc />
        protected override void AddToppings()
        {
            Console.WriteLine("加入鳳梨與火腿...");
        }
    }

    /// <summary>
    /// 海鮮披薩的製作流程
    /// </summary>
    public class SeafoodPizzaMaker : PizzaMaker
    {
        /// <inheritdoc />
        protected override void AddToppings()
        {
            Console.WriteLine("加入鮮蝦、章魚和起司...");
        }
    }

    /// <summary>
    /// 模板方法模式範例主程式
    /// </summary>
    public static class TemplateMethodDemo
    {
        public static void Main()
        {
            PizzaMaker hawaiianPizza = new HawaiianPizzaMaker();
            hawaiianPizza.MakePizza();

            Console.WriteLine();

            PizzaMaker seafoodPizza = new SeafoodPizzaMaker();
            seafoodPizza.MakePizza();
        }
    }
}

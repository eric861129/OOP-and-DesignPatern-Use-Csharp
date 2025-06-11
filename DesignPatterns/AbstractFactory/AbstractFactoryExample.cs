using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 椅子介面
    /// </summary>
    public interface IChair
    {
        /// <summary>
        /// 坐在椅子上
        /// </summary>
        void SitOn();
    }

    /// <summary>
    /// 桌子介面
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// 使用桌子
        /// </summary>
        void Use();
    }

    /// <summary>
    /// 現代風格椅子
    /// </summary>
    public class ModernChair : IChair
    {
        public void SitOn() => Console.WriteLine("坐在現代風格的椅子上。");
    }

    /// <summary>
    /// 現代風格桌子
    /// </summary>
    public class ModernTable : ITable
    {
        public void Use() => Console.WriteLine("使用現代風格的桌子。");
    }

    /// <summary>
    /// 古典風格椅子
    /// </summary>
    public class ClassicChair : IChair
    {
        public void SitOn() => Console.WriteLine("坐在古典風格的椅子上。");
    }

    /// <summary>
    /// 古典風格桌子
    /// </summary>
    public class ClassicTable : ITable
    {
        public void Use() => Console.WriteLine("使用古典風格的桌子。");
    }

    /// <summary>
    /// 家具抽象工廠介面
    /// </summary>
    public interface IFurnitureFactory
    {
        /// <summary>
        /// 建立椅子
        /// </summary>
        IChair CreateChair();

        /// <summary>
        /// 建立桌子
        /// </summary>
        ITable CreateTable();
    }

    /// <summary>
    /// 現代風格家具工廠
    /// </summary>
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ModernChair();
        public ITable CreateTable() => new ModernTable();
    }

    /// <summary>
    /// 古典風格家具工廠
    /// </summary>
    public class ClassicFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair() => new ClassicChair();
        public ITable CreateTable() => new ClassicTable();
    }

    /// <summary>
    /// 示範如何使用抽象工廠模式
    /// </summary>
    public static class AbstractFactoryDemo
    {
        public static void Main()
        {
            // 購買現代風格家具
            IFurnitureFactory modernFactory = new ModernFurnitureFactory();
            IChair modernChair = modernFactory.CreateChair();
            ITable modernTable = modernFactory.CreateTable();
            modernChair.SitOn();
            modernTable.Use();

            Console.WriteLine();

            // 購買古典風格的家具
            IFurnitureFactory classicFactory = new ClassicFurnitureFactory();
            IChair classicChair = classicFactory.CreateChair();
            ITable classicTable = classicFactory.CreateTable();
            classicChair.SitOn();
            classicTable.Use();
        }
    }
}

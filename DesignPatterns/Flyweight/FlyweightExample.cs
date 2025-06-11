using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 樹木介面，定義顯示方法
    /// </summary>
    public interface ITree
    {
        /// <summary>
        /// 在指定座標顯示樹木
        /// </summary>
        /// <param name="x">座標 X</param>
        /// <param name="y">座標 Y</param>
        void Display(int x, int y);
    }

    /// <summary>
    /// 具體享元類別，代表一種樹木
    /// </summary>
    public class Tree : ITree
    {
        private readonly string _treeType;

        /// <summary>
        /// 以樹種建構樹木實例
        /// </summary>
        /// <param name="treeType">樹種</param>
        public Tree(string treeType)
        {
            _treeType = treeType;
            Console.WriteLine($"建立了一個 {treeType} 樹物件。");
        }

        /// <inheritdoc />
        public void Display(int x, int y)
        {
            Console.WriteLine($"在位置 ({x}, {y}) 顯示一棵{_treeType}樹。");
        }
    }

    /// <summary>
    /// 享元工廠，負責管理與重複使用樹木實例
    /// </summary>
    public class TreeFactory
    {
        private readonly Dictionary<string, ITree> _trees = new();

        /// <summary>
        /// 取得指定樹種的樹木實例，若不存在則建立新的
        /// </summary>
        /// <param name="treeType">樹種</param>
        public ITree GetTree(string treeType)
        {
            if (!_trees.ContainsKey(treeType))
            {
                _trees[treeType] = new Tree(treeType);
            }
            return _trees[treeType];
        }
    }

    /// <summary>
    /// 示範如何使用享元模式
    /// </summary>
    public static class FlyweightDemo
    {
        public static void Main()
        {
            var treeFactory = new TreeFactory();

            // 建立多個樹木，但實際上共用相同實例
            var oak = treeFactory.GetTree("橡樹");
            oak.Display(1, 1);
            oak.Display(2, 5);

            var maple = treeFactory.GetTree("楓樹");
            maple.Display(3, 3);
            maple.Display(4, 8);

            // 再次取得橡樹，會使用既有實例
            var anotherOak = treeFactory.GetTree("橡樹");
            anotherOak.Display(5, 5);
        }
    }
}

using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 檔案系統元件介面
    /// </summary>
    public interface IFileSystemComponent
    {
        /// <summary>
        /// 以層級顯示自身資訊
        /// </summary>
        /// <param name="depth">顯示縮排層級</param>
        void Display(int depth);
    }

    /// <summary>
    /// 資料夾，屬於樹枝節點
    /// </summary>
    public class Folder : IFileSystemComponent
    {
        // 資料夾名稱
        private readonly string _name;
        // 底下的檔案或子資料夾
        private readonly List<IFileSystemComponent> _components = new();

        /// <summary>
        /// 建立資料夾
        /// </summary>
        /// <param name="name">資料夾名稱</param>
        public Folder(string name)
        {
            _name = name;
        }

        /// <summary>
        /// 新增檔案或資料夾
        /// </summary>
        /// <param name="component">要加入的元件</param>
        public void Add(IFileSystemComponent component)
        {
            _components.Add(component);
        }

        /// <summary>
        /// 移除檔案或資料夾
        /// </summary>
        /// <param name="component">要移除的元件</param>
        public void Remove(IFileSystemComponent component)
        {
            _components.Remove(component);
        }

        /// <inheritdoc />
        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + _name);
            foreach (var component in _components)
            {
                component.Display(depth + 2);
            }
        }
    }

    /// <summary>
    /// 檔案，屬於樹葉節點
    /// </summary>
    public class File : IFileSystemComponent
    {
        // 檔案名稱
        private readonly string _name;

        /// <summary>
        /// 建立檔案
        /// </summary>
        /// <param name="name">檔案名稱</param>
        public File(string name)
        {
            _name = name;
        }

        /// <inheritdoc />
        public void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + _name);
        }
    }

    /// <summary>
    /// 組合模式範例主程式
    /// </summary>
    public static class CompositeDemo
    {
        public static void Main()
        {
            // 建立根目錄
            Folder root = new Folder("根目錄");

            // 新增檔案與子資料夾
            root.Add(new File("檔案A.txt"));
            root.Add(new File("檔案B.jpg"));

            Folder sub = new Folder("子資料夾");
            sub.Add(new File("檔案C.doc"));
            root.Add(sub);

            // 顯示整個目錄結構
            root.Display(1);
        }
    }
}

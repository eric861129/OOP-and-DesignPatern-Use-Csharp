using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 履歷表原型介面
    /// </summary>
    public interface IResume
    {
        /// <summary>
        /// 複製出新的履歷表
        /// </summary>
        IResume Clone();

        /// <summary>
        /// 顯示履歷內容
        /// </summary>
        void Show();
    }

    /// <summary>
    /// 履歷表
    /// </summary>
    public class Resume : IResume
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工作經歷
        /// </summary>
        public string Experience { get; set; }

        public Resume(string name, string experience)
        {
            Name = name;
            Experience = experience;
        }

        /// <summary>
        /// 複製一份新的履歷表
        /// </summary>
        public IResume Clone()
        {
            // 直接使用 MemberwiseClone 進行淺層複製
            return (IResume)MemberwiseClone();
        }

        /// <summary>
        /// 顯示履歷資訊
        /// </summary>
        public void Show()
        {
            Console.WriteLine($"姓名：{Name}，工作經歷：{Experience}");
        }
    }

    /// <summary>
    /// 示範原型模式的使用
    /// </summary>
    public static class PrototypeDemo
    {
        public static void Main()
        {
            // 原始履歷
            Resume resumeOriginal = new Resume("小明", "軟體工程師，3年經驗");
            resumeOriginal.Show();

            // 複製後修改
            Resume resumeCopy = (Resume)resumeOriginal.Clone();
            resumeCopy.Name = "小美";
            resumeCopy.Show();
        }
    }
}

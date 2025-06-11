using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 檔案介面，定義顯示方法
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// 顯示檔案內容
        /// </summary>
        void Display();
    }

    /// <summary>
    /// 真實的檔案存取物件
    /// </summary>
    public class RealFile : IFile
    {
        private readonly string _fileName;

        /// <summary>
        /// 建立實際檔案物件並從磁碟載入
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        public RealFile(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk(fileName);
        }

        /// <summary>
        /// 從磁碟載入檔案（模擬耗時操作）
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        private void LoadFromDisk(string fileName)
        {
            Console.WriteLine($"從磁碟載入檔案：{fileName}");
        }

        /// <inheritdoc />
        public void Display()
        {
            Console.WriteLine($"顯示檔案：{_fileName}");
        }
    }

    /// <summary>
    /// 檔案代理，控制實際檔案的存取
    /// </summary>
    public class ProxyFile : IFile
    {
        private RealFile _realFile;
        private readonly string _fileName;
        private readonly bool _hasPermission;

        /// <summary>
        /// 建立代理物件
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <param name="hasPermission">是否有存取權限</param>
        public ProxyFile(string fileName, bool hasPermission)
        {
            _fileName = fileName;
            _hasPermission = hasPermission;
        }

        /// <inheritdoc />
        public void Display()
        {
            if (_hasPermission)
            {
                // 延遲建立實際檔案
                if (_realFile == null)
                {
                    _realFile = new RealFile(_fileName);
                }

                _realFile.Display();
            }
            else
            {
                Console.WriteLine("您沒有存取此檔案的權限。");
            }
        }
    }

    /// <summary>
    /// 示範如何使用代理模式
    /// </summary>
    public static class ProxyDemo
    {
        public static void Main()
        {
            // 有權限存取檔案
            IFile fileWithPermission = new ProxyFile("secret.docx", true);
            fileWithPermission.Display();

            Console.WriteLine();

            // 無權限存取檔案
            IFile fileWithoutPermission = new ProxyFile("secret.docx", false);
            fileWithoutPermission.Display();
        }
    }
}

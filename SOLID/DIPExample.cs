namespace SolidExamples
{
    /// <summary>
    /// 列印服務，高階模組
    /// </summary>
    public class ReportService
    {
        private readonly IPrinter _printer;

        /// <summary>
        /// 建構式注入列印器
        /// </summary>
        public ReportService(IPrinter printer)
        {
            _printer = printer;
        }

        /// <summary>
        /// 產生報表並列印
        /// </summary>
        public void Print(string content)
        {
            _printer.Print(content);
        }
    }

    /// <summary>
    /// 列印器介面
    /// </summary>
    public interface IPrinter
    {
        void Print(string content);
    }

    /// <summary>
    /// 具體的低階列印實作
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        public void Print(string content)
        {
            System.Console.WriteLine(content);
        }
    }
}

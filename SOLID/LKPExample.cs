namespace SolidExamples
{
    /// <summary>
    /// 顯示訊息的控制器
    /// </summary>
    public class MessageController
    {
        private readonly MessageService _service = new MessageService();

        public void Show()
        {
            // 只與 MessageService 溝通
            string msg = _service.GetMessage();
            System.Console.WriteLine(msg);
        }
    }

    /// <summary>
    /// 提供訊息的服務
    /// </summary>
    public class MessageService
    {
        public string GetMessage()
        {
            return new MessageProvider().Text;
        }
    }

    /// <summary>
    /// 訊息來源
    /// </summary>
    public class MessageProvider
    {
        public string Text => "Hello";
    }
}

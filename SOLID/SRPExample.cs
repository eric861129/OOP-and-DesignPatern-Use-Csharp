namespace SolidExamples
{
    /// <summary>
    /// 訂單服務，負責新增訂單
    /// </summary>
    public class OrderService
    {
        private readonly OrderProcessor _processor = new OrderProcessor();
        private readonly OrderRepository _repository = new OrderRepository();
        private readonly OrderNotifier _notifier = new OrderNotifier();

        /// <summary>
        /// 新增訂單
        /// </summary>
        public void AddOrder(Order order)
        {
            _processor.Process(order);
            _repository.Create(order);
            _notifier.Notify(order);
        }
    }

    /// <summary>訂單模型</summary>
    public class Order
    {
        /// <summary>訂單編號</summary>
        public string OrderNo { get; set; }
    }

    /// <summary>
    /// 處理訂單邏輯的類別
    /// </summary>
    public class OrderProcessor
    {
        public void Process(Order order)
        {
            // 處理訂單相關邏輯
        }
    }

    /// <summary>
    /// 負責資料庫存取
    /// </summary>
    public class OrderRepository
    {
        public void Create(Order order)
        {
            // 將訂單寫入資料庫
        }
    }

    /// <summary>
    /// 負責通知客戶
    /// </summary>
    public class OrderNotifier
    {
        public void Notify(Order order)
        {
            // 發送通知信件
        }
    }
}

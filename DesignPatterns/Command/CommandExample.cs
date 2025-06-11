using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 命令介面，所有命令都必須實作 Execute 方法
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 執行命令
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// 具體命令：點餐
    /// </summary>
    public class OrderCommand : ICommand
    {
        private readonly Kitchen _kitchen;
        private readonly string _dish;

        /// <summary>
        /// 建立點餐命令
        /// </summary>
        /// <param name="kitchen">接收者：廚房</param>
        /// <param name="dish">要準備的餐點</param>
        public OrderCommand(Kitchen kitchen, string dish)
        {
            _kitchen = kitchen;
            _dish = dish;
        }

        /// <inheritdoc />
        public void Execute()
        {
            _kitchen.PrepareDish(_dish);
        }
    }

    /// <summary>
    /// 接收者：負責實際烹飪的廚房
    /// </summary>
    public class Kitchen
    {
        /// <summary>
        /// 準備指定餐點
        /// </summary>
        /// <param name="dish">餐點名稱</param>
        public void PrepareDish(string dish)
        {
            Console.WriteLine($"廚房正在準備：{dish}");
        }
    }

    /// <summary>
    /// 調用者：服務生，負責收集並送出訂單
    /// </summary>
    public class Waiter
    {
        private readonly List<ICommand> _orders = new();

        /// <summary>
        /// 接受顧客點餐
        /// </summary>
        /// <param name="command">點餐命令</param>
        public void TakeOrder(ICommand command)
        {
            _orders.Add(command);
        }

        /// <summary>
        /// 送出所有訂單給廚房
        /// </summary>
        public void SubmitOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }

    /// <summary>
    /// 示範如何使用命令模式
    /// </summary>
    public static class CommandDemo
    {
        public static void Main()
        {
            Kitchen kitchen = new Kitchen();
            Waiter waiter = new Waiter();

            ICommand order1 = new OrderCommand(kitchen, "牛排");
            ICommand order2 = new OrderCommand(kitchen, "沙拉");

            waiter.TakeOrder(order1);
            waiter.TakeOrder(order2);

            waiter.SubmitOrders();
        }
    }
}

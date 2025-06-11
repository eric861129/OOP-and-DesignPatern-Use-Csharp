using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 抽象處理者，負責定義處理請求的方法
    /// </summary>
    public abstract class Approver
    {
        /// <summary>
        /// 下一位處理者
        /// </summary>
        protected Approver _nextApprover;

        /// <summary>
        /// 設定下一位處理者
        /// </summary>
        /// <param name="approver">下一位處理者</param>
        public void SetNext(Approver approver)
        {
            _nextApprover = approver;
        }

        /// <summary>
        /// 處理請求的抽象方法
        /// </summary>
        /// <param name="amount">申請金額</param>
        public abstract void HandleRequest(decimal amount);
    }

    /// <summary>
    /// 主管，可處理較小金額的請求
    /// </summary>
    public class Supervisor : Approver
    {
        /// <inheritdoc />
        public override void HandleRequest(decimal amount)
        {
            if (amount <= 1000)
            {
                Console.WriteLine($"主管批准了金額 {amount} 的請求。");
            }
            else if (_nextApprover != null)
            {
                _nextApprover.HandleRequest(amount);
            }
        }
    }

    /// <summary>
    /// 經理，可處理中等金額的請求
    /// </summary>
    public class Manager : Approver
    {
        /// <inheritdoc />
        public override void HandleRequest(decimal amount)
        {
            if (amount <= 5000)
            {
                Console.WriteLine($"經理批准了金額 {amount} 的請求。");
            }
            else if (_nextApprover != null)
            {
                _nextApprover.HandleRequest(amount);
            }
        }
    }

    /// <summary>
    /// 總經理，處理所有剩餘請求
    /// </summary>
    public class GeneralManager : Approver
    {
        /// <inheritdoc />
        public override void HandleRequest(decimal amount)
        {
            Console.WriteLine($"總經理批准了金額 {amount} 的請求。");
        }
    }

    /// <summary>
    /// 示範如何使用責任鏈模式
    /// </summary>
    public static class ChainOfResponsibilityDemo
    {
        public static void Main()
        {
            Approver supervisor = new Supervisor();
            Approver manager = new Manager();
            Approver generalManager = new GeneralManager();

            supervisor.SetNext(manager);
            manager.SetNext(generalManager);

            supervisor.HandleRequest(500);
            supervisor.HandleRequest(3000);
            supervisor.HandleRequest(8000);
        }
    }
}

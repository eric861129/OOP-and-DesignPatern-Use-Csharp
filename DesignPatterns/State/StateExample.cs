using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 手機狀態介面
    /// </summary>
    public interface IMobileState
    {
        /// <summary>
        /// 觸發提示行為
        /// </summary>
        void Alert();
    }

    /// <summary>
    /// 響鈴模式
    /// </summary>
    public class RingingState : IMobileState
    {
        /// <inheritdoc />
        public void Alert()
        {
            Console.WriteLine("手機正在響鈴...");
        }
    }

    /// <summary>
    /// 靜音模式
    /// </summary>
    public class SilentState : IMobileState
    {
        /// <inheritdoc />
        public void Alert()
        {
            Console.WriteLine("手機處於靜音模式。");
        }
    }

    /// <summary>
    /// 手機內容，根據狀態改變行為
    /// </summary>
    public class MobileContext
    {
        private IMobileState _state;

        /// <summary>
        /// 建立手機並設定初始狀態
        /// </summary>
        /// <param name="initialState">初始狀態</param>
        public MobileContext(IMobileState initialState)
        {
            _state = initialState;
        }

        /// <summary>
        /// 切換手機狀態
        /// </summary>
        /// <param name="state">新的狀態</param>
        public void SetState(IMobileState state)
        {
            _state = state;
        }

        /// <summary>
        /// 執行提示動作
        /// </summary>
        public void Alert()
        {
            _state.Alert();
        }
    }

    /// <summary>
    /// 示範狀態模式
    /// </summary>
    public static class StateDemo
    {
        public static void Main()
        {
            MobileContext mobile = new MobileContext(new SilentState());
            mobile.Alert();

            mobile.SetState(new RingingState());
            mobile.Alert();
        }
    }
}

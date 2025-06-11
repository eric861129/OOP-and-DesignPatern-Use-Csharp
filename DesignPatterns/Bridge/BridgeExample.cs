using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 電視裝置介面
    /// </summary>
    public interface ITV
    {
        /// <summary>
        /// 開機
        /// </summary>
        void On();

        /// <summary>
        /// 關機
        /// </summary>
        void Off();

        /// <summary>
        /// 設定頻道
        /// </summary>
        /// <param name="channel">頻道號碼</param>
        void SetChannel(int channel);
    }

    /// <summary>
    /// Sony 電視實作
    /// </summary>
    public class SonyTV : ITV
    {
        public void On() => Console.WriteLine("Sony 電視開機");
        public void Off() => Console.WriteLine("Sony 電視關機");
        public void SetChannel(int channel) => Console.WriteLine($"Sony 電視設定頻道：{channel}");
    }

    /// <summary>
    /// Samsung 電視實作
    /// </summary>
    public class SamsungTV : ITV
    {
        public void On() => Console.WriteLine("Samsung 電視開機");
        public void Off() => Console.WriteLine("Samsung 電視關機");
        public void SetChannel(int channel) => Console.WriteLine($"Samsung 電視設定頻道：{channel}");
    }

    /// <summary>
    /// 遙控器抽象類別
    /// </summary>
    public abstract class RemoteControl
    {
        protected ITV tv;

        /// <summary>
        /// 建立遙控器並指定要控制的電視
        /// </summary>
        /// <param name="tv">電視實作</param>
        protected RemoteControl(ITV tv)
        {
            this.tv = tv;
        }

        /// <summary>
        /// 開機
        /// </summary>
        public abstract void TurnOn();

        /// <summary>
        /// 關機
        /// </summary>
        public abstract void TurnOff();

        /// <summary>
        /// 設定頻道
        /// </summary>
        /// <param name="channel">頻道號碼</param>
        public abstract void SetChannel(int channel);
    }

    /// <summary>
    /// 基本遙控器
    /// </summary>
    public class BasicRemote : RemoteControl
    {
        public BasicRemote(ITV tv) : base(tv) { }

        public override void TurnOn() => tv.On();
        public override void TurnOff() => tv.Off();
        public override void SetChannel(int channel) => tv.SetChannel(channel);
    }

    /// <summary>
    /// 智慧型遙控器
    /// </summary>
    public class SmartRemote : RemoteControl
    {
        public SmartRemote(ITV tv) : base(tv) { }

        public override void TurnOn()
        {
            Console.WriteLine("使用智慧型遙控器：");
            tv.On();
        }

        public override void TurnOff()
        {
            Console.WriteLine("使用智慧型遙控器：");
            tv.Off();
        }

        public override void SetChannel(int channel)
        {
            Console.WriteLine("使用智慧型遙控器設定頻道：");
            tv.SetChannel(channel);
        }
    }

    /// <summary>
    /// 橋接模式範例主程式
    /// </summary>
    public static class BridgeDemo
    {
        public static void Main()
        {
            ITV sonyTV = new SonyTV();
            ITV samsungTV = new SamsungTV();

            RemoteControl basicRemote = new BasicRemote(sonyTV);
            basicRemote.TurnOn();
            basicRemote.SetChannel(10);
            basicRemote.TurnOff();

            Console.WriteLine();

            RemoteControl smartRemote = new SmartRemote(samsungTV);
            smartRemote.TurnOn();
            smartRemote.SetChannel(5);
            smartRemote.TurnOff();
        }
    }
}

namespace SolidExamples
{
    /// <summary>
    /// 鳥類基底
    /// </summary>
    public class Bird
    {
        /// <summary>鳥名</summary>
        public string Name { get; set; }
    }

    /// <summary>會飛的鳥</summary>
    public class Sparrow : Bird, IFlyable
    {
        public void Fly()
        {
            // 麻雀展翅飛翔
        }
    }

    /// <summary>企鵝，不會飛</summary>
    public class Penguin : Bird
    {
        // 沒有 Fly 方法，仍可當作 Bird 使用
    }

    /// <summary>
    /// 可飛行介面
    /// </summary>
    public interface IFlyable
    {
        void Fly();
    }
}

namespace SolidExamples
{
    /// <summary>
    /// 跑步能力
    /// </summary>
    public interface IRun
    {
        void Run();
    }

    /// <summary>
    /// 飛行能力
    /// </summary>
    public interface IFly
    {
        void Fly();
    }

    /// <summary>
    /// 游泳能力
    /// </summary>
    public interface ISwim
    {
        void Swim();
    }

    /// <summary>
    /// 企鵝只需要跑步與游泳
    /// </summary>
    public class IspPenguin : IRun, ISwim
    {
        public void Run()
        {
            // 企鵝慢慢跑
        }

        public void Swim()
        {
            // 企鵝在水中游泳
        }
    }
}

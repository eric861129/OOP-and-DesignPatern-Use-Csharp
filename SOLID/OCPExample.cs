namespace SolidExamples
{
    /// <summary>
    /// 面積計算器，透過 IShape 介面擴充不同形狀
    /// </summary>
    public class AreaService
    {
        /// <summary>
        /// 計算面積
        /// </summary>
        public double GetArea(IShape shape)
        {
            return shape.Area();
        }
    }

    /// <summary>
    /// 形狀介面
    /// </summary>
    public interface IShape
    {
        /// <summary>取得面積</summary>
        double Area();
    }

    /// <summary>正方形</summary>
    public class Square : IShape
    {
        /// <summary>邊長</summary>
        public int Length { get; set; }

        public double Area()
        {
            return Length * Length;
        }
    }

    /// <summary>圓形</summary>
    public class Circle : IShape
    {
        /// <summary>半徑</summary>
        public int Radius { get; set; }

        public double Area()
        {
            return Radius * Radius * 3.14;
        }
    }
}

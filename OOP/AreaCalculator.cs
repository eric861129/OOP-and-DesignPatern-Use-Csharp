namespace OOPExample
{
    /// <summary>
    /// 面積計算工具
    /// </summary>
    public static class AreaCalculator
    {
        /// <summary>
        /// 計算正方形面積
        /// </summary>
        public static int GetArea(int length)
        {
            return length * length;
        }

        /// <summary>
        /// 計算長方形面積
        /// </summary>
        public static int GetArea(int height, int width)
        {
            return width * height;
        }

        /// <summary>
        /// 計算圓形面積
        /// </summary>
        public static double GetArea(int radius, double pi)
        {
            return radius * radius * pi;
        }
    }
}

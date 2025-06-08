using System;

namespace OOPExample
{
    /// <summary>
    /// 汽車資訊模型
    /// </summary>
    public class CarModel
    {
        /// <summary>
        /// 汽車品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 車款類型
        /// </summary>
        public string CarType { get; set; }

        /// <summary>
        /// 座位數量
        /// </summary>
        public int Seat { get; set; }

        /// <summary>
        /// 製造日期
        /// </summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>
        /// 製造年份字串
        /// </summary>
        public string ManufactureYearStr
        {
            get { return ManufactureDate.ToString("yyyy"); }
        }

        /// <summary>
        /// 售價
        /// </summary>
        public decimal Price { get; set; }
    }
}

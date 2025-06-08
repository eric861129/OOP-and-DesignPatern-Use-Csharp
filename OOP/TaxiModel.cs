using System;

namespace OOPExample
{
    /// <summary>
    /// 計程車模型，繼承自 CarModel
    /// </summary>
    public class TaxiModel : CarModel
    {
        /// <summary>
        /// 司機姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 司齡
        /// </summary>
        public int Seniority { get; set; }
    }
}

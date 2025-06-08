using System;

namespace OOPExample
{
    /// <summary>
    /// 示範如何建立物件並使用類別
    /// </summary>
    public static class Program
    {
        public static void Main()
        {
            // 建立計程車物件
            TaxiModel taxi = new TaxiModel
            {
                Brand = "Toyota",
                CarType = "Hatchback",
                Seat = 5,
                ManufactureDate = DateTime.Parse("2019/02/10"),
                Price = 700000,
                DriverName = "小明",
                Seniority = 10
            };

            Console.WriteLine($"{taxi.Brand} 計程車司機 {taxi.DriverName} 已服務 {taxi.Seniority} 年");
        }
    }
}

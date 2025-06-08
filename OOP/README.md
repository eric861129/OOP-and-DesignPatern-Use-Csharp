# 物件導向基本概念

## 兩大基礎概念

1. 類別 Class
2. 物件 Object

## 三大特性

1. 封裝
2. 繼承
3. 多型

---

## 類別 Class

在程式語言中，類別定義一件事物的抽象特點。類別的定義包含了資料的形式（屬性，Field）以及對資料的操作（方法，Method）。我們也可以想像成類別是汽車的設計藍圖（blueprint），其中我們可以在這張藍圖定義抽象的內容，例如汽車的廠牌、車名與馬力，以及取得汽車資訊等。

```csharp
namespace OOPExample
{
    /// <summary>
    /// 汽車資訊模型
    /// </summary>
    public class CarModel
    {
        /// <summary>汽車品牌</summary>
        public string Brand { get; set; }

        /// <summary>車款類型</summary>
        public string CarType { get; set; }

        /// <summary>座位數量</summary>
        public int Seat { get; set; }

        /// <summary>製造日期</summary>
        public DateTime ManufactureDate { get; set; }

        /// <summary>製造年份字串</summary>
        public string ManufactureYearStr
        {
            get { return ManufactureDate.ToString("yyyy"); }
        }

        /// <summary>售價</summary>
        public decimal Price { get; set; }
    }
}
```

---

## 物件 Object

物件是類別的實例，有了類別這張藍圖後，可以在程式中產生多個汽車物件，而這些物件彼此獨立、互不影響。

```csharp
var mazdaM3 = new CarModel
{
    Brand = "Mazda",
    CarType = "Hatchback",
    Seat = 5,
    ManufactureDate = DateTime.Parse("2020/10/10"),
    Price = 990000
};

var bmwX5 = new CarModel
{
    Brand = "BMW",
    CarType = "SUV",
    Seat = 5,
    ManufactureDate = DateTime.Parse("2018/10/10"),
    Price = 2590000
};
```

---

## 封裝

封裝將物件內部的資料隱藏起來，只能透過物件提供的介面存取。外部無法直接更動或查看物件的內部狀態，必須經由物件提供的方法處理。

---

## 繼承

在某些情況下，類別會有「子類別」。子類別繼承父類別的屬性與方法，並可加入自身特有的成員。例如計程車繼承汽車的特性，並加入司機姓名等屬性。

```csharp
namespace OOPExample
{
    /// <summary>
    /// 計程車模型，繼承自 CarModel
    /// </summary>
    public class TaxiModel : CarModel
    {
        /// <summary>司機姓名</summary>
        public string DriverName { get; set; }

        /// <summary>司齡</summary>
        public int Seniority { get; set; }
    }
}

var toyotaAltisTaxi = new TaxiModel
{
    Brand = "Toyota",
    CarType = "Hatchback",
    Seat = 5,
    ManufactureDate = DateTime.Parse("2019/02/10"),
    Price = 700000,
    DriverName = "小明",
    Seniority = 10
};
```

---

## 多型

多型（Polymorphism）可讓相同名稱的方法依照參數不同而有不同的行為。以下示範在同一個類別中定義多個 `GetArea` 方法，傳入不同參數計算不同形狀的面積。

```csharp
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
```

---

這些範例展示了類別、物件、封裝、繼承與多型的基本概念，並以簡易的 C# 程式碼說明，方便閱讀與理解。

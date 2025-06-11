# Abstract Factory 抽象工廠模式

嗨各位朋友～前面我們介紹過了 Singleton 和 Factory Method，今天要繼續往下走，聊一個稍微進階一點點的設計模式：「抽象工廠模式（Abstract Factory）」。

## 🌟 什麼是抽象工廠模式？

簡單來說，抽象工廠模式就是提供一個介面，讓你可以建立一整系列相關的產品，而不需要關心產品具體的實作方式。

舉個例子，今天你到 IKEA 買家具，通常會想要一次買齊同一系列的產品，比如椅子、桌子、書架等等。如果這些家具都是同系列，外觀看起來會很搭調，品質和風格也會一致。這樣的一個系列產品，就是抽象工廠想幫你解決的問題！

---

## 🧐 抽象工廠模式適合什麼場景？

以下情境適合用抽象工廠模式解決：

- 你的產品需要有不同的系列或主題，每個系列內又有多個相關產品。
- 想要保證同系列產品之間能夠完美兼容。
- 未來可能需要新增更多產品系列，而希望盡可能避免修改現有程式碼。

---

## 🛋️ C# 抽象工廠模式範例

這次，我們就用「家具工廠」作為範例來示範抽象工廠模式的實作吧！

### 1️⃣ 定義產品介面

```csharp
// 椅子介面
public interface IChair
{
    void SitOn();
}

// 桌子介面
public interface ITable
{
    void Use();
}
```

### 🛋️ 建立具體產品（現代系列和古典系列）

```csharp
using System;

// 現代風格椅子
public class ModernChair : IChair
{
    public void SitOn() => Console.WriteLine("坐在現代風格的椅子上。");
}

// 現代風格桌子
public class ModernTable : ITable
{
    public void Use() => Console.WriteLine("使用現代風格的桌子。");
}

// 古典風格椅子
public class ClassicChair : IChair
{
    public void SitOn() => Console.WriteLine("坐在古典風格的椅子上。");
}

// 古典風格桌子
public class ClassicTable : ITable
{
    public void Use() => Console.WriteLine("使用古典風格的桌子。");
}
```

### 🏭 建立抽象工廠與具體工廠

```csharp
// 家具抽象工廠介面
public interface IFurnitureFactory
{
    IChair CreateChair();
    ITable CreateTable();
}

// 現代風格家具工廠
public class ModernFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ModernChair();
    public ITable CreateTable() => new ModernTable();
}

// 古典風格家具工廠
public class ClassicFurnitureFactory : IFurnitureFactory
{
    public IChair CreateChair() => new ClassicChair();
    public ITable CreateTable() => new ClassicTable();
}
```

### 🚀 實際使用工廠範例

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // 購買現代風格家具
        IFurnitureFactory modernFactory = new ModernFurnitureFactory();
        var modernChair = modernFactory.CreateChair();
        var modernTable = modernFactory.CreateTable();
        modernChair.SitOn();
        modernTable.Use();

        Console.WriteLine();

        // 購買古典風格的家具
        IFurnitureFactory classicFactory = new ClassicFurnitureFactory();
        var classicChair = classicFactory.CreateChair();
        var classicTable = classicFactory.CreateTable();
        classicChair.SitOn();
        classicTable.Use();
    }
}
```

### 🎯 執行結果

```
使用現代風格的桌子。
坐在現代風格的椅子上。

使用古典風格的桌子。
坐在古典風格的椅子上。
```

---

## ⚠️ 使用抽象工廠模式要注意什麼？

- 好處：容易維護與擴充，同一個產品系列可以輕鬆管理。
- 缺點是新增產品可能需要增加許多類別，有時候會顯得比較繁瑣。

---

## 🎉 結語

恭喜你又掌握了一個超實用的設計模式！透過抽象工廠模式，你可以輕鬆管理一整套產品系列，讓你的程式碼變得更加靈活。

接下來我們會繼續探索更多模式，一樣輕鬆有趣又實用，記得持續關注喔！下次見啦～

---

程式碼範例請見 [AbstractFactoryExample.cs](AbstractFactoryExample.cs)。

# Prototype 原型模式

嗨！繼續設計模式系列，這次要介紹的主角是**原型模式（Prototype）**。聽到「原型」這個詞是不是有點不太確定這到底是什麼？別擔心，我們還是用輕鬆易懂的方式來理解它吧！

## 🌟 原型模式到底在做什麼？

原型模式簡單來說就是透過「複製」現有的物件，來建立一個新物件。聽起來是不是覺得很熟悉？沒錯，就像我們常用的「複製貼上」一樣。

比如你去文具店要印名片，你只需要給店員一張原稿，他就能根據這份原稿複製出許多張一模一樣的名片，而不用一張一張重新設計。

---

## 🤔 什麼時候該用原型模式？

以下情況你可以考慮用原型模式：

- 物件的建立成本較高（例如需要從資料庫讀取大量資料）。
- 你要建立的物件跟現有物件差異不大，只需要稍微修改一下就可以使用。
- 希望降低物件建立時的複雜度與耗時。

---

## 📑 C# 原型模式範例

這次我們就以「履歷表複製」作為實際案例，來看看怎麼使用原型模式吧！

### 📄 定義原型介面

```csharp
// 原型介面，提供複製方法
public interface IResume
{
    IResume Clone();
    void Show();
}
```

### 📄 實作具體原型類別

```csharp
using System;

// 履歷表
public class Resume : IResume
{
    public string Name { get; set; }
    public string Experience { get; set; }

    public Resume(string name, string experience)
    {
        Name = name;
        Experience = experience;
    }

    // 實現複製方法
    public IResume Clone()
    {
        return (IResume)this.MemberwiseClone();
    }

    public void Show()
    {
        Console.WriteLine($"姓名：{Name}，工作經歷：{Experience}");
    }
}
```

### 🚀 實際使用範例

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // 原始履歷
        Resume resumeOriginal = new Resume("小明", "軟體工程師，3年經驗");
        resumeOriginal.Show();

        // 複製出新的履歷表，稍作修改
        Resume resumeCopy = (Resume)resumeOriginal.Clone();
        resumeCopy.Name = "小美";
        resumeCopy.Show();
    }
}
```

### 🎯 執行結果

```
姓名：小明，工作經歷：軟體工程師，3年經驗
姓名：小美，工作經歷：3年經驗
```

---

## ⚠️ 原型模式的使用注意事項

- 優點：可以大幅提升效能，節省建立新物件的時間與成本。
- 缺點：當物件結構非常複雜時，深層複製可能會比較複雜。

---

## 🎉 結語

太棒啦～你又成功學會了一個設計模式：原型模式（Prototype）！這個模式能幫助我們快速又有效率地製造出一系列類似的物件，讓程式更快速、更高效。

我們會繼續帶你探索其他設計模式，用輕鬆的方式陪你一起進步，敬請期待下一篇囉！

喜歡的話記得收藏與分享，我們下篇見！

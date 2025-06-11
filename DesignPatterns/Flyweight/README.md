# Flyweight 享元模式

享元模式能透過共享重複的物件來節省記憶體使用量，
特別適合在系統中有大量類似物件的情況。

## 🤔 適用情境

- 存在大量重複的物件。
- 物件建立成本高，而資料多半相同。
- 希望減少記憶體占用並提升效能。

## 🌳 C# 範例

以下以遊戲中常見的「樹木」為例，示範如何實作享元模式。
完整程式碼請見 [FlyweightExample.cs](FlyweightExample.cs)。

```csharp
// 享元介面
public interface ITree
{
    void Display(int x, int y);
}

// 具體享元
public class Tree : ITree
{
    private string _treeType;

    public Tree(string treeType)
    {
        _treeType = treeType;
        Console.WriteLine($"建立了一個 {treeType} 樹物件。");
    }

    public void Display(int x, int y)
    {
        Console.WriteLine($"在位置 ({x}, {y}) 顯示一棵{_treeType}樹。");
    }
}

// 享元工廠
public class TreeFactory
{
    private Dictionary<string, ITree> _trees = new Dictionary<string, ITree>();

    public ITree GetTree(string treeType)
    {
        if (!_trees.ContainsKey(treeType))
        {
            _trees[treeType] = new Tree(treeType);
        }
        return _trees[treeType];
    }
}

// 使用範例
class Program
{
    static void Main(string[] args)
    {
        var treeFactory = new TreeFactory();
        var oak = treeFactory.GetTree("橡樹");
        oak.Display(1, 1);
        oak.Display(2, 5);
        var maple = treeFactory.GetTree("楓樹");
        maple.Display(3, 3);
        maple.Display(4, 8);
        var anotherOak = treeFactory.GetTree("橡樹");
        anotherOak.Display(5, 5);
    }
}
```

### 🎯 執行結果

```
建立了一個 橡樹 樹物件。
在位置 (1, 1) 顯示一棵橡樹樹。
在位置 (2, 5) 顯示一棵橡樹樹。
建立了一個 楓樹 樹物件。
在位置 (3, 3) 顯示一棵楓樹樹。
在位置 (4, 8) 顯示一棵楓樹樹。
在位置 (5, 5) 顯示一棵橡樹樹。
```

## ⚠️ 使用提醒

- 優點：大量重複物件時節省記憶體。
- 缺點：需要額外的工廠管理共享物件。

透過享元模式，就能有效減少系統資源消耗囉！

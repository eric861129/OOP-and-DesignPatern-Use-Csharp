# Visitor 訪問者模式

訪問者模式讓你在不改變資料結構的情況下，
可以在既有物件上新增不同的操作或行為。

## 🤔 適用情境

- 需要對一系列物件新增多種不同的操作
- 不想修改既有類別結構，又想擴充功能
- 物件結構相對穩定，但操作可能常常變動

## 🎢 C# 範例

範例程式位於 [VisitorExample.cs](VisitorExample.cs)。

```csharp
// 設施介面
public interface IAmusementFacility
{
    void Accept(IVisitor visitor);
}

// 訪問者介面
public interface IVisitor
{
    void Visit(RollerCoaster rollerCoaster);
    void Visit(FerrisWheel ferrisWheel);
}
```

### 🎯 執行結果

```
成人訪客進入遊樂園：
成人訪客很享受雲霄飛車的刺激！
成人訪客悠閒地坐著摩天輪欣賞風景。

小孩訪客進入遊樂園：
小孩訪客覺得雲霄飛車太可怕了！
小孩訪客開心地乘坐摩天輪。
```

透過 Visitor 模式，可以自由地為設施新增訪客類型，
而不需要修改設施的程式碼，讓系統更具彈性。

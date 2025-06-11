# Template Method 模板方法模式

模板方法模式定義一系列固定流程，細節交由子類別實作，確保演算法結構一致又具彈性。

## 🤔 適用情境

- 多個流程步驟相同但細節不同時
- 希望固定演算法骨架，避免子類別任意更動
- 需要重複利用流程並可靈活擴充

## 🍕 C# 範例

以下以製作不同口味的披薩為例，完整程式碼請見 [TemplateMethodExample.cs](TemplateMethodExample.cs)。

```csharp
// 抽象披薩製作流程
public abstract class PizzaMaker
{
    public void MakePizza()
    {
        PrepareDough();
        AddSauce();
        AddToppings();
        BakePizza();
    }

    protected abstract void AddToppings();
}
```

### 🎯 執行結果

```
揉製麵團...
加入醬料...
加入鳳梨與火腿...
烤製披薩...

揉製麵團...
加入醬料...
加入鮮蝦、章魚和起司...
烤製披薩...
```

---

## ⚠️ 注意事項

- 優點：流程固定，細節可彈性實作，利於程式碼重用。
- 缺點：抽象類別可能因步驟太多而複雜化，需適度拆分。

透過模板方法模式，我們能輕鬆維持流程一致，並依需求變換細節。

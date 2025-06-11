# Decorator 裝飾者模式

裝飾者模式能在不修改原有類別的情況下，動態地為物件加入新功能。就像買飲料時加珍珠或椰果一樣，可以自由組合。

## 🌟 什麼是裝飾者模式？

透過建立一個基底裝飾者類別，其他裝飾者繼承自它，並持有被裝飾的物件。每個裝飾者在呼叫原物件功能前後，可加入額外行為，以達到擴充目的。

## 🤔 什麼時候適合使用？

- 需要在執行期間動態增加或移除功能
- 希望保持原始類別程式碼穩定不變
- 想用不同組合彈性擴充功能

## ☕ 範例程式

以下以咖啡加料為例，完整程式碼見 [DecoratorExample.cs](DecoratorExample.cs)。

```csharp
// 基本咖啡
Coffee coffee = new SimpleCoffee();
// 加牛奶
coffee = new MilkDecorator(coffee);
// 再加糖漿
coffee = new SyrupDecorator(coffee);

Console.WriteLine(coffee.GetDescription());
Console.WriteLine($"總價格：{coffee.GetCost()} 元");
```

### 🎯 執行結果

```
基本咖啡 + 牛奶 + 糖漿
總價格：65 元
```

---

裝飾者模式能讓功能擴充更具彈性，也能避免過度使用繼承造成的類別膨脹。

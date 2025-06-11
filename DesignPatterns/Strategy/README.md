# Strategy 策略模式

策略模式允許我們在執行期間動態切換演算法，
避免大量 `if-else` 判斷，使程式更彈性易於擴充。

## 🤔 適用情境

- 需要根據不同狀況選擇不同演算法時
- 想將演算法獨立封裝，方便替換與擴充
- 避免在程式中寫下過多條件判斷

## 🚌 範例說明

以旅遊選擇交通方式為例，詳見 [StrategyExample.cs](StrategyExample.cs)。

```csharp
// 交通策略介面
public interface ITravelStrategy
{
    void Travel(string destination);
}
```

```csharp
// 旅客根據策略選擇交通工具
public class Traveler
{
    private ITravelStrategy? _travelStrategy;

    public void SetStrategy(ITravelStrategy strategy)
    {
        _travelStrategy = strategy;
    }

    public void TravelTo(string destination)
    {
        _travelStrategy?.Travel(destination);
    }
}
```

### 🎯 執行結果

```
搭飛機前往 東京
搭高鐵前往 台南
開車前往 宜蘭
```

---

## ⚠️ 注意事項

- 優點：行為可自由替換，易於維護與擴充。
- 缺點：策略類別可能增加，需妥善管理。

透過策略模式，我們能讓程式根據需要選擇最合適的行為。

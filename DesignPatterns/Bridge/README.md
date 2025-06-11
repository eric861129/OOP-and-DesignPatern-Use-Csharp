# Bridge 橋接模式

哈囉大家～今天要跟各位分享的是 **橋接模式（Bridge）**。

## 🌟 橋接模式是什麼？

橋接模式的核心概念是「將抽象與實作分離」，讓它們能各自獨立變化。可以想成是遙控器與電視之間的關係：遙控器的類型（普通或智慧型）與電視品牌（Sony、Samsung…）都可以自由搭配，不必相互耦合。

## 🤔 什麼時候適合用橋接模式？

- 想避免抽象與實作之間的緊密耦合
- 系統有多個維度需要獨立擴充
- 希望降低類別數量，讓架構更彈性

---

## 📺 C# 橋接模式範例

以下示範如何用遙控器控制不同品牌的電視，完整程式碼請見 [BridgeExample.cs](BridgeExample.cs)。

```csharp
// 電視介面
public interface ITV
{
    void On();
    void Off();
    void SetChannel(int channel);
}

// Sony 電視實作
public class SonyTV : ITV
{
    public void On() => Console.WriteLine("Sony 電視開機");
    // ...其餘實作
}

// 遙控器抽象類別
public abstract class RemoteControl
{
    protected ITV tv;
    protected RemoteControl(ITV tv) { this.tv = tv; }
    public abstract void TurnOn();
    // ...
}
```

### 🎯 執行結果

```
Sony 電視開機
Sony 電視設定頻道：10
Sony 電視關機

使用智慧型遙控器：
Samsung 電視開機
使用智慧型遙控器設定頻道：
Samsung 電視設定頻道：5
使用智慧型遙控器：
Samsung 電視關機
```

---

## ⚠️ 使用橋接模式注意事項

- 優點：降低耦合度，讓抽象與實作各自獨立發展
- 缺點：初期設計需要規劃清楚，類別結構可能稍微複雜

---

## 🎉 結語

橋接模式能有效地分離抽象與實作，讓系統更具彈性與擴充性。下次面對多重維度變化的需求時，不妨試試看這個模式吧！

程式碼範例請見 [BridgeExample.cs](BridgeExample.cs)。

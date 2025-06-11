# Adapter 介面卡模式

哈囉大家！今天我們要介紹的設計模式是 **介面卡模式（Adapter）**，又稱為轉接器模式。

## 🌟 介面卡模式到底在做什麼？

介面卡模式就像旅行時常用的插座轉接頭，讓原本不相容的介面可以順利地溝通合作。

## 🤔 什麼時候適合用 Adapter？

- 已有的類別或系統介面與現有程式不相容時。
- 想使用外部套件但介面不同，希望在不修改原始程式碼的情況下整合。
- 想快速解決介面不一致的問題並保持原有程式碼穩定。

---

## 🔌 C# Adapter 模式範例

以下以「充電器轉接頭」為例示範。完整程式碼請參考 [AdapterExample.cs](AdapterExample.cs)。

```csharp
// 既有的歐洲插座
public class EuropeanSocket
{
    public void SpecificRequest() => Console.WriteLine("使用歐洲規格的插座");
}

// 台灣插頭介面
public interface ITaiwanPlug
{
    void Request();
}

// 介面卡：將歐洲插座轉成台灣插頭可用
public class PlugAdapter : ITaiwanPlug
{
    private readonly EuropeanSocket _europeanSocket;

    public PlugAdapter(EuropeanSocket socket)
    {
        _europeanSocket = socket;
    }

    public void Request()
    {
        _europeanSocket.SpecificRequest();
        Console.WriteLine("透過介面卡轉接，順利連接到台灣插頭。");
    }
}

class Program
{
    static void Main(string[] args)
    {
        EuropeanSocket europeanSocket = new EuropeanSocket();
        ITaiwanPlug adapter = new PlugAdapter(europeanSocket);
        adapter.Request();
    }
}
```

### 🎯 執行結果

```
使用歐洲規格的插座
透過介面卡轉接，順利連接到台灣插頭。
```

---

## ⚠️ 使用 Adapter 模式小提醒

- 優點：可以在不更動既有程式碼的前提下整合不同介面。
- 缺點：若介面卡過多可能會讓架構較為複雜。

---

## 🎉 結語

透過介面卡模式，我們能讓原本不相容的介面順利協作，極大化程式碼的重用性與彈性。

程式碼範例請見 [AdapterExample.cs](AdapterExample.cs)。

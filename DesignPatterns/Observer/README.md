# Observer 觀察者模式

觀察者模式定義一對多的依賴關係，當主題物件狀態改變時，所有觀察者都會收到通知。

## 🤔 適用情境

- 需要在狀態改變時自動通知相關物件
- 想降低物件之間的耦合度
- 系統可能有多個觀察者需要同步更新

## 🔔 C# 範例

以下以 YouTube 頻道訂閱通知為例，完整程式碼請見 [ObserverExample.cs](ObserverExample.cs)。

```csharp
// 主題介面
public interface IChannel
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void NotifySubscribers(string videoTitle);
}
```

```csharp
// 具體主題：YouTube 頻道
public class YouTubeChannel : IChannel
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    public string ChannelName { get; private set; }

    public YouTubeChannel(string name)
    {
        ChannelName = name;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string videoTitle)
    {
        foreach (var sub in _subscribers)
        {
            sub.Update(ChannelName, videoTitle);
        }
    }
}
```

### 🎯 執行結果

```
有趣頻道 發佈了新影片：「設計模式教學 - 觀察者模式篇」
Alice 收到通知：有趣頻道 上傳了新影片「設計模式教學 - 觀察者模式篇」
Bob 收到通知：有趣頻道 上傳了新影片「設計模式教學 - 觀察者模式篇」
```

---

## ⚠️ 注意事項

- 優點：可實現物件之間的鬆散耦合，易於擴充維護。
- 缺點：觀察者過多時可能增加通知成本。

透過觀察者模式，我們能輕鬆實現事件通知機制。

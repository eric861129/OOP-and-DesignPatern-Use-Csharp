# Mediator 中介者模式

中介者模式透過引入 "中介者" 物件，統一協調其他物件的互動，
讓物件之間不需要直接參考彼此，降低耦合度。

## 🤔 適用情境

- 系統內多個物件需要彼此溝通，導致依賴過於複雜
- 想集中管理物件間的溝通邏輯
- 希望物件之間保持鬆耦合，方便日後維護

---

## 💬 C# 範例

以下以聊天室為例，完整程式碼請見 [MediatorExample.cs](MediatorExample.cs)。

```csharp
// 中介者介面
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}
```

```csharp
// 具體中介者：聊天室
public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();

    public void RegisterUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive(message, sender.Name);
        }
    }
}
```

更多細節請參考程式碼檔案。

### 🎯 執行結果

```
Alice 發送訊息：大家好！
Bob 收到來自 Alice 的訊息：大家好！
Charlie 收到來自 Alice 的訊息：大家好！
Bob 發送訊息：嗨 Alice！
Alice 收到來自 Bob 的訊息：嗨 Alice！
Charlie 收到來自 Bob 的訊息：嗨 Alice！
```

---

## ⚠️ 注意事項

- 優點：集中管理互動邏輯，物件間耦合度低
- 缺點：中介者可能會變得複雜，需要留意維護成本

透過中介者模式，我們可以更清楚地管理物件間的溝通關係。

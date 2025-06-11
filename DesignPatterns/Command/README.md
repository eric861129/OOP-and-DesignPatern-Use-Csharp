# Command 命令模式

命令模式將「動作」封裝成獨立物件，讓呼叫端可以自由地排程、延遲或撤銷命令。

## 🤔 適用情境

- 想將觸發動作的物件與真正執行動作的物件解耦。
- 需要排程或撤銷命令。
- 想將請求歷史記錄起來以利追蹤。

---

## 🍔 C# 範例

以下以餐廳點餐為例，完整程式碼請見 [CommandExample.cs](CommandExample.cs)。

```csharp
// 命令介面
public interface ICommand
{
    void Execute();
}
```

```csharp
// 具體命令：點餐
public class OrderCommand : ICommand
{
    private Kitchen _kitchen;
    private string _dish;

    public OrderCommand(Kitchen kitchen, string dish)
    {
        _kitchen = kitchen;
        _dish = dish;
    }

    public void Execute()
    {
        _kitchen.PrepareDish(_dish);
    }
}
```

更多細節請參考程式碼檔案。

### 🎯 執行結果

```
廚房正在準備：牛排
廚房正在準備：沙拉
```

---

## ⚠️ 注意事項

- 優點：可輕鬆處理命令排程、撤銷以及記錄。
- 缺點：若命令類別過多，系統複雜度可能上升。

透過命令模式，我們可以讓系統的指令更靈活、好管理。

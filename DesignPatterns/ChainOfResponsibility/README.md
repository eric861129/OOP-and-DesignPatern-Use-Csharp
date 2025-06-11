# Chain of Responsibility 責任鏈模式

責任鏈模式會將請求沿著一條「處理鏈」逐一傳遞，
直到有物件能處理為止，
常用來解耦請求端與處理端之間的關係。

## 🤔 什麼時候適合用？

- 多個物件都可能處理同一請求，處理條件各自不同。
- 處理順序可能改變，希望能動態調整責任鏈。
- 想降低請求與處理者的耦合度。

## 💼 C# 範例

以下以「費用審核流程」為例，示範如何實作責任鏈模式。
完整程式碼請見 [ChainOfResponsibilityExample.cs](ChainOfResponsibilityExample.cs)。

```csharp
// 抽象處理者
public abstract class Approver
{
    protected Approver _nextApprover;
    public void SetNext(Approver approver)
    {
        _nextApprover = approver;
    }
    public abstract void HandleRequest(decimal amount);
}

// 主管
public class Supervisor : Approver
{
    public override void HandleRequest(decimal amount)
    {
        if (amount <= 1000)
        {
            Console.WriteLine($"主管批准了金額 {amount} 的請求。");
        }
        else if (_nextApprover != null)
        {
            _nextApprover.HandleRequest(amount);
        }
    }
}

// 經理
public class Manager : Approver
{
    public override void HandleRequest(decimal amount)
    {
        if (amount <= 5000)
        {
            Console.WriteLine($"經理批准了金額 {amount} 的請求。");
        }
        else if (_nextApprover != null)
        {
            _nextApprover.HandleRequest(amount);
        }
    }
}

// 總經理
public class GeneralManager : Approver
{
    public override void HandleRequest(decimal amount)
    {
        Console.WriteLine($"總經理批准了金額 {amount} 的請求。");
    }
}

// 使用範例
class Program
{
    static void Main(string[] args)
    {
        Approver supervisor = new Supervisor();
        Approver manager = new Manager();
        Approver generalManager = new GeneralManager();
        supervisor.SetNext(manager);
        manager.SetNext(generalManager);
        supervisor.HandleRequest(500);
        supervisor.HandleRequest(3000);
        supervisor.HandleRequest(8000);
    }
}
```

### 🎯 執行結果

```
主管批准了金額 500 的請求。
經理批准了金額 3000 的請求。
總經理批准了金額 8000 的請求。
```

## ⚠️ 使用提醒

- 優點：降低請求端與處理端耦合，易於擴充。
- 缺點：鏈太長可能降低效能，也較難追蹤問題。

透過責任鏈模式，可彈性地處理不同條件的請求。

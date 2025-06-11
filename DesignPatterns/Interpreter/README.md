# Interpreter 解譯器模式

解譯器模式用來解析特定語言或指令，讓程式能理解使用者輸入並執行相應的行動。

## 🤔 什麼時候適合用？

- 需要處理自訂的指令或語法。
- 想打造易於擴充的指令解析系統。
- 系統需要理解並執行玩家輸入的操作。

## 🎮 C# 範例

以下以文字冒險遊戲為例，完整程式碼請見 [InterpreterExample.cs](InterpreterExample.cs)。

```csharp
// 抽象指令介面
public interface IGameCommand
{
    void Execute();
}
```

```csharp
// 指令解譯器
public static class GameCommandInterpreter
{
    public static IGameCommand Interpret(string commandText)
    {
        var parts = commandText.Split(' ');
        switch (parts[0])
        {
            case "攻擊":
                return new AttackCommand(parts[1], parts[3]);
            case "移動":
                return new MoveCommand(parts[1]);
            default:
                throw new InvalidOperationException("無法識別的指令");
        }
    }
}
```

執行結果：

```
你使用火球攻擊了巨龍！
你往北方移動了。
```

## ⚠️ 注意事項

- 優點：容易擴充語法規則，讓新指令能快速加入。
- 缺點：若語法過於複雜，程式可能較難維護。

# Memento 備忘錄模式

備忘錄模式可將物件狀態封裝起來，讓我們在需要時回復到之前的狀態，而不暴露其內部細節。

## 🤔 適用情境

- 提供 undo/redo 功能
- 需要保存並還原物件的多個歷史狀態
- 不希望外部直接存取物件的內部結構

## 🎮 C# 範例

以下以遊戲角色存檔為例，完整程式碼請見 [MementoExample.cs](MementoExample.cs)。

```csharp
// 備忘錄
public class GameMemento
{
    public int Level { get; }
    public int Health { get; }

    public GameMemento(int level, int health)
    {
        Level = level;
        Health = health;
    }
}
```

```csharp
// 角色可儲存與還原自身狀態
public class GameCharacter
{
    public int Level { get; set; }
    public int Health { get; set; }

    public GameMemento Save()
    {
        return new GameMemento(Level, Health);
    }

    public void Restore(GameMemento memento)
    {
        Level = memento.Level;
        Health = memento.Health;
    }
}
```

### 🎯 執行結果

```
目前狀態 => 等級：10，生命值：100
目前狀態 => 等級：12，生命值：50
目前狀態 => 等級：10，生命值：100
```

---

## ⚠️ 注意事項

- 優點：可輕鬆實作撤銷及回復功能，不暴露物件細節。
- 缺點：若狀態很多，儲存備忘錄可能占用較多記憶體。

透過備忘錄模式，我們能方便地管理物件的歷史狀態。

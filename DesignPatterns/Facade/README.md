# Facade 外觀模式

哈囉大家～今天要介紹的設計模式是 **外觀模式（Facade）**！
外觀模式可以幫助我們把複雜的系統封裝起來，
提供簡單好用的介面，就像按下遙控器就能讓電視自動完成一連串動作那樣方便。

## 🤔 什麼時候該用外觀模式？

- 當系統過於複雜，想簡化使用流程時。
- 希望提供統一的介面，隱藏底層細節。
- 降低模組之間的耦合度，讓維護更輕鬆。

---

## 🎬 C# Facade 範例

以下以「電影院系統」為例，示範如何實作外觀模式。
完整程式碼請見 [FacadeExample.cs](FacadeExample.cs)。

```csharp
// 建立複雜的子系統
public class Projector
{
    public void TurnOn() => Console.WriteLine("投影機已開啟。");
    public void TurnOff() => Console.WriteLine("投影機已關閉。");
}

public class AudioSystem
{
    public void TurnOn() => Console.WriteLine("音響系統已開啟。");
    public void TurnOff() => Console.WriteLine("音響系統已關閉。");
}

public class Lights
{
    public void DimLights() => Console.WriteLine("燈光已調暗。");
    public void TurnOff() => Console.WriteLine("燈光已關閉。");
    public void TurnOn() => Console.WriteLine("燈光已開啟。");
}

// 建立 Facade
public class HomeTheaterFacade
{
    private Projector _projector = new Projector();
    private AudioSystem _audioSystem = new AudioSystem();
    private Lights _lights = new Lights();

    public void WatchMovie()
    {
        Console.WriteLine("準備觀賞電影...");
        _projector.TurnOn();
        _audioSystem.TurnOn();
        _lights.TurnOff();
    }

    public void EndMovie()
    {
        Console.WriteLine("電影結束，準備關閉設備...");
        _projector.TurnOff();
        _audioSystem.TurnOff();
        _lights.TurnOn();
    }
}

// 實際使用
class Program
{
    static void Main(string[] args)
    {
        HomeTheaterFacade homeTheater = new HomeTheaterFacade();
        homeTheater.WatchMovie();
        Console.WriteLine();
        homeTheater.EndMovie();
    }
}
```

### 🎯 執行結果

```
準備觀賞電影...
投影機已開啟。
音響系統已開啟。
燈光已關閉。

電影結束，準備關閉設備...
投影機已關閉。
音響系統已關閉。
燈光已開啟。
```

---

## ⚠️ 使用小提醒

- 優點：簡化複雜系統的使用方式，降低耦合。
- 缺點：Facade 本身若過於龐大，仍可能造成維護負擔。

---

## 結語

透過外觀模式，我們能提供更友善的介面，
讓複雜的系統使用起來就像按下遙控器一樣簡單。
趕快來試試看吧！

程式碼範例請見 [FacadeExample.cs](FacadeExample.cs)。

# Singleton 單例模式


嗨各位，又見面啦！今天要跟大家聊的這個模式叫做「單例模式」（Singleton）。

先來個小故事吧！假設今天你開了一間非常特別的咖啡廳，這間咖啡廳全世界只有一家分店。不管你從哪裡出發、用什麼方式，最終都只能來到這一家。聽起來是不是很酷？單例模式其實就像這家咖啡廳，強調的是：

**「不管怎麼叫它，只會得到同一個實例（Instance）。」**

簡單說，就是保證一個類別在整個系統中只有一個物件實例存在，而且提供一個方便的存取點，讓所有人都可以輕鬆存取這個唯一的實例。

---

## 🤔 單例模式適合什麼情境使用？

通常我們會在以下情境考慮使用單例模式：

- **系統設定 (Configuration)：** 全系統共用同一份設定資料，確保設定的一致性。
- **日誌記錄 (Logging)：** 系統統一使用同一個日誌記錄入口，避免日誌內容混亂。
- **資料庫連線 (Database Connection)：** 管理單一資料庫連線，避免浪費資源和確保安全性。

總之，就是用在你「絕對只希望有一個物件」的時候啦！

---

## C# 單例模式的實作範例

我們這次就以「系統設定(Configuration)」作為實際使用案例，來看看怎麼用 Singleton 實作吧。

### 💻 Singleton 類別實作

```csharp
using System;

// 負責系統設定的 Singleton 類別
public sealed class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private static readonly object _lock = new object();

    // 假設有個設定值
    public string ConnectionString { get; private set; }

    private ConfigurationManager()
    {
        Console.WriteLine("建立 ConfigurationManager 唯一實例");
        // 模擬載入設定資料
        ConnectionString = "Server=myServer;Database=myDB;User Id=myUser;";
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }
    }
}
```

### 🚀 Singleton 實際呼叫與使用範例

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        // 第一次呼叫建立實例
        ConfigurationManager config1 = ConfigurationManager.Instance;

        // 第二次呼叫，拿到的還是同一個實例
        ConfigurationManager config2 = ConfigurationManager.Instance;

        if (config1 == config2)
        {
            Console.WriteLine("確認過眼神，是同一個 Singleton 實例！");
            Console.WriteLine("設定資料庫連線字串為：" + config1.ConnectionString);
        }
    }
}
```

### 🎯 執行結果：

```
建立 ConfigurationManager 唯一實例
確認過眼神，是同一個 Singleton 實例！
設定資料庫連線字串為：Server=myServer;Database=myDB;User Id=myUser;
```

---

## Singleton 的注意事項

雖然單例模式很好用，但使用的時候也要注意一些小問題：

- 如果過度使用單例模式，可能導致程式難以測試。
- 它會成為全域狀態，可能增加程式的耦合性。

## 結語

恭喜你學會了第一個設計模式：**Singleton**！

有沒有覺得這東西簡單又實用呢？接下來，我會繼續用這種輕鬆、好理解的方式，把更多的設計模式介紹給大家。

另外，之後介紹的所有範例程式碼都會放在 GitHub 上公開，讓你邊看邊玩！期待下篇再見囉～

有任何問題歡迎隨時留言告訴我，我們下次見！

---

程式碼範例請見 [SingletonExample.cs](SingletonExample.cs)。

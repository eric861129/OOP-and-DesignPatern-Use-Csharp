# Proxy 代理模式

代理模式透過引入「代理人」控制對真實物件的存取，
可以在不直接操作真實物件的情況下，加入額外的權限檢查或延遲載入等功能。

## 🤔 什麼時候使用代理模式？

- 需要控制物件的存取權限
- 想延遲建立昂貴的物件
- 在不改變原有物件的情況下加入額外行為

---

## 🛂 C# 代理模式範例

以下以檔案存取權限控制為例，完整程式碼請見 [ProxyExample.cs](ProxyExample.cs)。

```csharp
// 共通介面
public interface IFile
{
    void Display();
}

// 真實的檔案物件
public class RealFile : IFile
{
    private string _fileName;

    public RealFile(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk(fileName);
    }

    private void LoadFromDisk(string fileName)
    {
        Console.WriteLine($"從磁碟載入檔案：{fileName}");
    }

    public void Display()
    {
        Console.WriteLine($"顯示檔案：{_fileName}");
    }
}

// 代理類別
public class ProxyFile : IFile
{
    private RealFile _realFile;
    private string _fileName;
    private bool _hasPermission;

    public ProxyFile(string fileName, bool hasPermission)
    {
        _fileName = fileName;
        _hasPermission = hasPermission;
    }

    public void Display()
    {
        if (_hasPermission)
        {
            if (_realFile == null)
                _realFile = new RealFile(_fileName);
            _realFile.Display();
        }
        else
        {
            Console.WriteLine("您沒有存取此檔案的權限。");
        }
    }
}

// 使用範例
class Program
{
    static void Main(string[] args)
    {
        IFile fileWithPermission = new ProxyFile("secret.docx", true);
        fileWithPermission.Display();

        Console.WriteLine();

        IFile fileWithoutPermission = new ProxyFile("secret.docx", false);
        fileWithoutPermission.Display();
    }
}
```

### 🎯 執行結果

```
從磁碟載入檔案：secret.docx
顯示檔案：secret.docx

您沒有存取此檔案的權限。
```

---

## ⚠️ 注意事項

- 優點：能加強存取控制，或在不影響真實物件情況下加入功能
- 缺點：若代理過多，可能讓系統架構變得複雜

透過代理模式，我們可以更安全、彈性地管理物件存取。

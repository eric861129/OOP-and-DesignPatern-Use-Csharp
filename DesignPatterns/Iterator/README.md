# Iterator 迭代器模式

迭代器模式讓你可以逐一瀏覽集合中的元素，而不必暴露集合的內部結構。
以下以「音樂播放清單」為例說明，完整程式碼請見 [IteratorExample.cs](IteratorExample.cs)。

```csharp
// 抽象迭代器
public interface IIterator
{
    bool HasNext();
    string Next();
}
```

```csharp
// 播放清單與迭代器
public class Playlist
{
    private List<string> _songs = new List<string>();
    public void AddSong(string song) => _songs.Add(song);
    public IIterator GetIterator() => new PlaylistIterator(_songs);
}

public class PlaylistIterator : IIterator
{
    private List<string> _songs;
    private int _index = 0;
    public PlaylistIterator(List<string> songs) { _songs = songs; }
    public bool HasNext() => _index < _songs.Count;
    public string Next() => HasNext() ? _songs[_index++] : null;
}
```

執行範例：

```csharp
var playlist = new Playlist();
playlist.AddSong("Song A");
playlist.AddSong("Song B");
var iterator = playlist.GetIterator();
while (iterator.HasNext())
{
    Console.WriteLine($"正在播放：{iterator.Next()}");
}
```

### 🎯 執行結果

```
正在播放：Song A
正在播放：Song B
```

## ⚠️ 使用提醒

- 優點：遍歷集合時不需關心內部結構，且可套用於不同集合類型。
- 缺點：可能需要額外的迭代器類別，增加系統複雜度。

透過迭代器模式，能讓集合操作更加直覺、好維護。

using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 迭代器介面，定義遍歷集合的方法
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// 是否還有下一個元素
        /// </summary>
        /// <returns>是否仍有元素可供迭代</returns>
        bool HasNext();

        /// <summary>
        /// 取得下一個元素
        /// </summary>
        /// <returns>下一個元素字串</returns>
        string Next();
    }

    /// <summary>
    /// 播放清單，管理多首歌曲
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// 儲存歌曲清單
        /// </summary>
        private readonly List<string> _songs = new();

        /// <summary>
        /// 新增歌曲到清單
        /// </summary>
        /// <param name="song">歌曲名稱</param>
        public void AddSong(string song)
        {
            _songs.Add(song);
        }

        /// <summary>
        /// 取得此清單的迭代器
        /// </summary>
        /// <returns>可逐一取出歌曲的迭代器</returns>
        public IIterator GetIterator()
        {
            return new PlaylistIterator(_songs);
        }
    }

    /// <summary>
    /// 播放清單專用的迭代器
    /// </summary>
    public class PlaylistIterator : IIterator
    {
        private readonly List<string> _songs;
        private int _currentIndex = 0;

        /// <summary>
        /// 建立迭代器並指定歌曲來源
        /// </summary>
        /// <param name="songs">歌曲集合</param>
        public PlaylistIterator(List<string> songs)
        {
            _songs = songs;
        }

        /// <inheritdoc />
        public bool HasNext()
        {
            return _currentIndex < _songs.Count;
        }

        /// <inheritdoc />
        public string Next()
        {
            return HasNext() ? _songs[_currentIndex++] : null;
        }
    }

    /// <summary>
    /// 示範如何使用迭代器模式
    /// </summary>
    public static class IteratorDemo
    {
        public static void Main()
        {
            var playlist = new Playlist();
            playlist.AddSong("Song A");
            playlist.AddSong("Song B");
            playlist.AddSong("Song C");

            IIterator iterator = playlist.GetIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine($"正在播放：{iterator.Next()}");
            }
        }
    }
}

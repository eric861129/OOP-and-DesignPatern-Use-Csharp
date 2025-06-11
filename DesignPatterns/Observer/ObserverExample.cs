using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 主題介面，提供訂閱與通知功能
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// 訂閱頻道
        /// </summary>
        /// <param name="subscriber">訂閱者</param>
        void Subscribe(ISubscriber subscriber);

        /// <summary>
        /// 取消訂閱
        /// </summary>
        /// <param name="subscriber">訂閱者</param>
        void Unsubscribe(ISubscriber subscriber);

        /// <summary>
        /// 通知所有訂閱者有新影片
        /// </summary>
        /// <param name="videoTitle">影片標題</param>
        void NotifySubscribers(string videoTitle);
    }

    /// <summary>
    /// YouTube 頻道，具體實作主題介面
    /// </summary>
    public class YouTubeChannel : IChannel
    {
        private readonly List<ISubscriber> _subscribers = new();

        /// <summary>
        /// 頻道名稱
        /// </summary>
        public string ChannelName { get; }

        /// <summary>
        /// 以頻道名稱建立實例
        /// </summary>
        /// <param name="name">頻道名稱</param>
        public YouTubeChannel(string name)
        {
            ChannelName = name;
        }

        /// <inheritdoc />
        public void Subscribe(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        /// <inheritdoc />
        public void Unsubscribe(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        /// <inheritdoc />
        public void NotifySubscribers(string videoTitle)
        {
            Console.WriteLine($"{ChannelName} 發佈了新影片：「{videoTitle}」");
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(ChannelName, videoTitle);
            }
        }
    }

    /// <summary>
    /// 觀察者介面
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// 接收更新通知
        /// </summary>
        /// <param name="channelName">頻道名稱</param>
        /// <param name="videoTitle">影片標題</param>
        void Update(string channelName, string videoTitle);
    }

    /// <summary>
    /// 具體觀察者：訂閱者
    /// </summary>
    public class Subscriber : ISubscriber
    {
        /// <summary>
        /// 訂閱者名稱
        /// </summary>
        public string SubscriberName { get; }

        /// <summary>
        /// 以訂閱者名稱建立實例
        /// </summary>
        /// <param name="name">名稱</param>
        public Subscriber(string name)
        {
            SubscriberName = name;
        }

        /// <inheritdoc />
        public void Update(string channelName, string videoTitle)
        {
            Console.WriteLine($"{SubscriberName} 收到通知：{channelName} 上傳了新影片「{videoTitle}」");
        }
    }

    /// <summary>
    /// 示範觀察者模式
    /// </summary>
    public static class ObserverDemo
    {
        public static void Main()
        {
            YouTubeChannel channel = new YouTubeChannel("有趣頻道");

            Subscriber alice = new Subscriber("Alice");
            Subscriber bob = new Subscriber("Bob");

            channel.Subscribe(alice);
            channel.Subscribe(bob);

            channel.NotifySubscribers("設計模式教學 - 觀察者模式篇");
        }
    }
}

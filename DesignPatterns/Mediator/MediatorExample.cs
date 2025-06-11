using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 中介者介面，負責協調使用者之間的訊息傳遞
    /// </summary>
    public interface IChatMediator
    {
        /// <summary>
        /// 發送訊息給所有使用者
        /// </summary>
        /// <param name="message">訊息內容</param>
        /// <param name="user">發送者</param>
        void SendMessage(string message, User user);

        /// <summary>
        /// 註冊使用者至聊天室
        /// </summary>
        /// <param name="user">使用者物件</param>
        void RegisterUser(User user);
    }

    /// <summary>
    /// 具體中介者：聊天室
    /// </summary>
    public class ChatMediator : IChatMediator
    {
        private readonly List<User> _users = new();

        /// <inheritdoc />
        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        /// <inheritdoc />
        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message, sender.Name);
                }
            }
        }
    }

    /// <summary>
    /// 參與聊天室的使用者
    /// </summary>
    public class User
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; }

        private readonly IChatMediator _chatMediator;

        /// <summary>
        /// 建立使用者並自動加入聊天室
        /// </summary>
        /// <param name="name">名稱</param>
        /// <param name="chatMediator">聊天室中介者</param>
        public User(string name, IChatMediator chatMediator)
        {
            Name = name;
            _chatMediator = chatMediator;
            _chatMediator.RegisterUser(this);
        }

        /// <summary>
        /// 發送訊息給聊天室
        /// </summary>
        /// <param name="message">訊息內容</param>
        public void Send(string message)
        {
            Console.WriteLine($"{Name} 發送訊息：{message}");
            _chatMediator.SendMessage(message, this);
        }

        /// <summary>
        /// 接收來自其他使用者的訊息
        /// </summary>
        /// <param name="message">訊息內容</param>
        /// <param name="senderName">發送者名稱</param>
        public void Receive(string message, string senderName)
        {
            Console.WriteLine($"{Name} 收到來自 {senderName} 的訊息：{message}");
        }
    }

    /// <summary>
    /// 示範如何使用中介者模式
    /// </summary>
    public static class MediatorDemo
    {
        public static void Main()
        {
            ChatMediator chatMediator = new ChatMediator();

            User alice = new User("Alice", chatMediator);
            User bob = new User("Bob", chatMediator);
            User charlie = new User("Charlie", chatMediator);

            alice.Send("大家好！");
            bob.Send("嗨 Alice！");
        }
    }
}

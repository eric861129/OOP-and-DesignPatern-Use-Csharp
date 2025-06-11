using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 備忘錄，紀錄遊戲角色的狀態
    /// </summary>
    public class GameMemento
    {
        /// <summary>
        /// 等級
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// 生命值
        /// </summary>
        public int Health { get; }

        /// <summary>
        /// 以角色等級與生命值建立備忘錄
        /// </summary>
        /// <param name="level">角色等級</param>
        /// <param name="health">角色生命值</param>
        public GameMemento(int level, int health)
        {
            Level = level;
            Health = health;
        }
    }

    /// <summary>
    /// 遊戲角色，可存取自身狀態
    /// </summary>
    public class GameCharacter
    {
        /// <summary>
        /// 角色等級
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 角色生命值
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// 顯示目前角色狀態
        /// </summary>
        public void DisplayStatus()
        {
            Console.WriteLine($"目前狀態 => 等級：{Level}，生命值：{Health}");
        }

        /// <summary>
        /// 儲存當前狀態
        /// </summary>
        /// <returns>角色狀態備忘錄</returns>
        public GameMemento Save()
        {
            return new GameMemento(Level, Health);
        }

        /// <summary>
        /// 從備忘錄還原狀態
        /// </summary>
        /// <param name="memento">先前儲存的備忘錄</param>
        public void Restore(GameMemento memento)
        {
            Level = memento.Level;
            Health = memento.Health;
        }
    }

    /// <summary>
    /// 負責管理備忘錄
    /// </summary>
    public class GameCaretaker
    {
        /// <summary>
        /// 儲存的備忘錄
        /// </summary>
        public GameMemento? Memento { get; set; }
    }

    /// <summary>
    /// 示範如何使用備忘錄模式
    /// </summary>
    public static class MementoDemo
    {
        public static void Main()
        {
            GameCharacter hero = new GameCharacter { Level = 10, Health = 100 };
            hero.DisplayStatus();

            // 存檔
            GameCaretaker caretaker = new GameCaretaker();
            caretaker.Memento = hero.Save();

            // 修改角色狀態
            hero.Level = 12;
            hero.Health = 50;
            hero.DisplayStatus();

            // 讀取存檔
            if (caretaker.Memento != null)
            {
                hero.Restore(caretaker.Memento);
                hero.DisplayStatus();
            }
        }
    }
}

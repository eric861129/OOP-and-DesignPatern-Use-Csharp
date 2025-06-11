using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 遊戲指令介面，所有指令都必須實作 Execute 方法
    /// </summary>
    public interface IGameCommand
    {
        /// <summary>
        /// 執行指令
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// 攻擊指令
    /// </summary>
    public class AttackCommand : IGameCommand
    {
        private readonly string _target;
        private readonly string _weapon;

        /// <summary>
        /// 建立攻擊指令
        /// </summary>
        /// <param name="target">攻擊目標</param>
        /// <param name="weapon">使用武器</param>
        public AttackCommand(string target, string weapon)
        {
            _target = target;
            _weapon = weapon;
        }

        /// <inheritdoc />
        public void Execute()
        {
            Console.WriteLine($"你使用{_weapon}攻擊了{_target}！");
        }
    }

    /// <summary>
    /// 移動指令
    /// </summary>
    public class MoveCommand : IGameCommand
    {
        private readonly string _direction;

        /// <summary>
        /// 建立移動指令
        /// </summary>
        /// <param name="direction">移動方向</param>
        public MoveCommand(string direction)
        {
            _direction = direction;
        }

        /// <inheritdoc />
        public void Execute()
        {
            Console.WriteLine($"你往{_direction}移動了。");
        }
    }

    /// <summary>
    /// 指令解譯器，將文字解析為具體指令
    /// </summary>
    public static class GameCommandInterpreter
    {
        /// <summary>
        /// 解析文字指令
        /// </summary>
        /// <param name="commandText">輸入的指令文字</param>
        /// <returns>解析後的指令物件</returns>
        /// <exception cref="InvalidOperationException">當指令無法辨識時拋出</exception>
        public static IGameCommand Interpret(string commandText)
        {
            var parts = commandText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return parts[0] switch
            {
                "攻擊" => new AttackCommand(parts[1], parts[3]),
                "移動" => new MoveCommand(parts[1]),
                _ => throw new InvalidOperationException("無法識別的指令")
            };
        }
    }

    /// <summary>
    /// 示範如何使用解譯器模式
    /// </summary>
    public static class InterpreterDemo
    {
        public static void Main()
        {
            var command1 = GameCommandInterpreter.Interpret("攻擊 巨龍 使用 火球");
            var command2 = GameCommandInterpreter.Interpret("移動 北方");

            command1.Execute();
            command2.Execute();
        }
    }
}

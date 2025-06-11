using System;

namespace DesignPatternExamples
{
    /// <summary>
    /// 電影院投影機
    /// </summary>
    public class Projector
    {
        /// <summary>
        /// 開啟投影機
        /// </summary>
        public void TurnOn() => Console.WriteLine("投影機已開啟。");

        /// <summary>
        /// 關閉投影機
        /// </summary>
        public void TurnOff() => Console.WriteLine("投影機已關閉。");
    }

    /// <summary>
    /// 音響系統
    /// </summary>
    public class AudioSystem
    {
        /// <summary>
        /// 開啟音響系統
        /// </summary>
        public void TurnOn() => Console.WriteLine("音響系統已開啟。");

        /// <summary>
        /// 關閉音響系統
        /// </summary>
        public void TurnOff() => Console.WriteLine("音響系統已關閉。");
    }

    /// <summary>
    /// 燈光控制
    /// </summary>
    public class Lights
    {
        /// <summary>
        /// 將燈光調暗
        /// </summary>
        public void DimLights() => Console.WriteLine("燈光已調暗。");

        /// <summary>
        /// 關閉燈光
        /// </summary>
        public void TurnOff() => Console.WriteLine("燈光已關閉。");

        /// <summary>
        /// 開啟燈光
        /// </summary>
        public void TurnOn() => Console.WriteLine("燈光已開啟。");
    }

    /// <summary>
    /// 外觀類別：整合控制電影院設備
    /// </summary>
    public class HomeTheaterFacade
    {
        private readonly Projector _projector;
        private readonly AudioSystem _audioSystem;
        private readonly Lights _lights;

        public HomeTheaterFacade()
        {
            _projector = new Projector();
            _audioSystem = new AudioSystem();
            _lights = new Lights();
        }

        /// <summary>
        /// 播放電影
        /// </summary>
        public void WatchMovie()
        {
            Console.WriteLine("準備觀賞電影...");
            _projector.TurnOn();
            _audioSystem.TurnOn();
            _lights.TurnOff();
        }

        /// <summary>
        /// 結束播放電影
        /// </summary>
        public void EndMovie()
        {
            Console.WriteLine("電影結束，準備關閉設備...");
            _projector.TurnOff();
            _audioSystem.TurnOff();
            _lights.TurnOn();
        }
    }

    /// <summary>
    /// 示範如何使用外觀模式
    /// </summary>
    public static class FacadeDemo
    {
        public static void Main()
        {
            HomeTheaterFacade homeTheater = new HomeTheaterFacade();

            homeTheater.WatchMovie();

            Console.WriteLine();

            homeTheater.EndMovie();
        }
    }
}

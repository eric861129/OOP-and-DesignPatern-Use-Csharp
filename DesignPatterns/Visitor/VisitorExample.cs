using System;
using System.Collections.Generic;

namespace DesignPatternExamples
{
    /// <summary>
    /// 設施介面，提供接受訪問者的方法
    /// </summary>
    public interface IAmusementFacility
    {
        /// <summary>
        /// 接受訪問者
        /// </summary>
        /// <param name="visitor">訪問者</param>
        void Accept(IVisitor visitor);
    }

    /// <summary>
    /// 雲霄飛車設施
    /// </summary>
    public class RollerCoaster : IAmusementFacility
    {
        /// <inheritdoc />
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 摩天輪設施
    /// </summary>
    public class FerrisWheel : IAmusementFacility
    {
        /// <inheritdoc />
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// 訪問者介面
    /// </summary>
    public interface IVisitor
    {
        /// <summary>
        /// 造訪雲霄飛車
        /// </summary>
        /// <param name="rollerCoaster">雲霄飛車物件</param>
        void Visit(RollerCoaster rollerCoaster);

        /// <summary>
        /// 造訪摩天輪
        /// </summary>
        /// <param name="ferrisWheel">摩天輪物件</param>
        void Visit(FerrisWheel ferrisWheel);
    }

    /// <summary>
    /// 成人訪客
    /// </summary>
    public class AdultVisitor : IVisitor
    {
        /// <inheritdoc />
        public void Visit(RollerCoaster rollerCoaster)
        {
            Console.WriteLine("成人訪客很享受雲霄飛車的刺激！");
        }

        /// <inheritdoc />
        public void Visit(FerrisWheel ferrisWheel)
        {
            Console.WriteLine("成人訪客悠閒地坐著摩天輪欣賞風景。");
        }
    }

    /// <summary>
    /// 小孩訪客
    /// </summary>
    public class ChildVisitor : IVisitor
    {
        /// <inheritdoc />
        public void Visit(RollerCoaster rollerCoaster)
        {
            Console.WriteLine("小孩訪客覺得雲霄飛車太可怕了！");
        }

        /// <inheritdoc />
        public void Visit(FerrisWheel ferrisWheel)
        {
            Console.WriteLine("小孩訪客開心地乘坐摩天輪。");
        }
    }

    /// <summary>
    /// 訪問者模式示範
    /// </summary>
    public static class VisitorDemo
    {
        public static void Main()
        {
            List<IAmusementFacility> facilities = new List<IAmusementFacility>
            {
                new RollerCoaster(),
                new FerrisWheel()
            };

            IVisitor adult = new AdultVisitor();
            IVisitor child = new ChildVisitor();

            Console.WriteLine("成人訪客進入遊樂園：");
            foreach (var facility in facilities)
            {
                facility.Accept(adult);
            }

            Console.WriteLine("\n小孩訪客進入遊樂園：");
            foreach (var facility in facilities)
            {
                facility.Accept(child);
            }
        }
    }
}

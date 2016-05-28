using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        public static object Thread { get; private set; }

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            HorizontalLine line1 = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine line2 = new HorizontalLine(0, 78, 24, '+');
            VerticalLine line3 = new VerticalLine(0, 24, 0, '+');
            VerticalLine line4 = new VerticalLine(0, 24, 78, '+');
            line1.Draw();
            line2.Draw();
            line3.Draw();
            line4.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
            snake.Move(); ;
            System.Threading.Thread.Sleep(300);
        }
    }
}

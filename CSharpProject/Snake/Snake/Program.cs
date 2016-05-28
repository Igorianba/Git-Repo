﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
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

            Point p1 = new Point(5, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            Console.ReadLine();
        }
    }
}

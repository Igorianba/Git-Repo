using System;
using Basic=Microsoft.SmallBasic.Library;

namespace Drawing
{
    class Program
    {
        #region 123

        static void Color()
        {
            Basic.GraphicsWindow.BackgroundColor = "Black";
            Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(255, 255, 255);
            Basic.GraphicsWindow.DrawRectangle(0, 0, 100, 100);
            Basic.GraphicsWindow.BrushColor = "Yellow";
            Basic.GraphicsWindow.FillEllipse(0, 0, 100, 100);
            Basic.GraphicsWindow.DrawEllipse(0, 0, 100, 100);
        }
        static void Gradient()
        {
            Basic.GraphicsWindow.Height = 255 + 255 + 255;
            Basic.GraphicsWindow.Width = 1000;
            for (int i = 0; i < 255; i++)
            {
                Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(i, 0, 0);
                Basic.GraphicsWindow.DrawLine(0, i, Basic.GraphicsWindow.Width, i);
            }
            for (int i = 0; i < 255; i++)
            {
                Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(0, i, 0);
                Basic.GraphicsWindow.DrawLine(0, 255 + i, Basic.GraphicsWindow.Width, 255 + i);
            }
            for (int i = 0; i < 255; i++)
            {
                Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(0, 0, i);
                Basic.GraphicsWindow.DrawLine(0, 510 + i, Basic.GraphicsWindow.Width, 510 + i);
            }
        }
        static void Colors16M()
        {
            int x = 0, y = 0;
            Basic.GraphicsWindow.Width = 1280;
            Basic.GraphicsWindow.Height = 1024;
            for (int r = 0; r < 256; r = r + 2)
                for (int g = 0; g < 256; g = g + 2)
                    for (int b = 0; b < 256; b = b + 2)
                    {
                        Basic.GraphicsWindow.SetPixel(x, y, Basic.GraphicsWindow.GetColorFromRGB(r, g, b));
                        x++;
                        if (x > Basic.GraphicsWindow.Width)
                        {
                            x = 0; y++;
                            if (y > Basic.GraphicsWindow.Height)
                            {
                                x = 0; y = 0;
                            }
                        }
                    }
        }
        static void Clock()
        {
            double x, y, size = 100;
            for (int angle = 0; angle <= 360; angle++)
            {
                Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(0, angle/2, angle/2);
                x = (size * Math.Cos(Math.PI / 180 * angle));
                y = (size * Math.Sin(Math.PI / 180 * angle));
                Basic.GraphicsWindow.SetPixel(100 + x, 100 + y, "Red");
                Basic.GraphicsWindow.DrawLine(300, 300, 300 + x, 300 + y);
                System.Threading.Thread.Sleep(50);
            }
        }
        static void Evolvent(double radius)
        {
            double x, y;
            Gradient();
            for (int angle = 0; angle <= 360; angle++)
            {
                Basic.GraphicsWindow.PenColor = Basic.GraphicsWindow.GetColorFromRGB(0, angle / 2, angle / 2);
                x = (radius * Math.Cos(Math.PI / 180 * angle) + radius * (Math.PI / 180 * angle)* Math.Sin(Math.PI / 180 * angle));
                y = (radius * Math.Sin(Math.PI / 180 * angle) - radius * (Math.PI / 180 * angle) * Math.Cos(Math.PI / 180 * angle));
                //Basic.GraphicsWindow.SetPixel(300 + x, 300 + y, "Red");
                Basic.GraphicsWindow.DrawLine(300, 400, 300 + x, 400 + y);
                Basic.GraphicsWindow.DrawLine(700, 400, 700 - x, 400 - y);
                System.Threading.Thread.Sleep(10);
            }
        }

        #endregion 123
        class DrawMan
        {
            double x, y;
            double angle = 0;

            public DrawMan(double _x, double _y, double _angle)
            {
                x = _x;
                y = _y;
                angle = _angle;
            }
            public void Rotate(double alpha)
            {
                angle = angle + alpha;
            }
            public void Run(int len)
            {
                double lenx = (len * Math.Cos(Math.PI / 180 * angle));
                double leny = (len * Math.Sin(Math.PI / 180 * angle));
                Basic.GraphicsWindow.DrawLine(x, y, x + lenx, y + leny);
                x = x + lenx;
                y = y + leny;
            }
        }
        static void Figure(DrawMan man, int angle)
        {
            man.Rotate(angle);
            for (int i = 0; i < 4; i++)
            {
                for (int n = 0; n < 8; n++)
                {
                    man.Run(15);
                    man.Rotate(45);
                }
                man.Rotate(90);
            }
        }
        static void Animation()
        {
            for (int k = 0; k < 360; k++)
                {
                    Basic.GraphicsWindow.Clear();
                    System.Threading.Thread.Sleep(20);
                }  
        }
        static void Main (string[] args)
        {
            //Color();
            //Gradient();
            //Colors16M();
            Basic.Sound.Play("D:\\My Music\\Music\\Чувава .mp3");
            Evolvent(50);
            Evolvent(-50);
            Evolvent(100);
            Evolvent(-100);
            Basic.Timer.Interval = 100;
            Basic.Timer.Tick += Timer_Tick;
        }

        static DrawMan man1 = new DrawMan(200, 400, 0);
        static DrawMan man2 = new DrawMan(400, 400, 0);
        static DrawMan man3 = new DrawMan(600, 400, 0);
        static DrawMan man4 = new DrawMan(800, 400, 0);

        public static void Timer_Tick()
        {
            Basic.GraphicsWindow.Clear();
            Figure(man1, 5);
            Figure(man2, 5);
            Figure(man3, -5);
            Figure(man4, -5);
        }
    }
}

using System;
using System.Diagnostics;
using System.Windows;
using System.Runtime.InteropServices;
using System.Threading;


namespace Prank1
{
    class Program
    {
        static void Main(string[] args)
        {

            ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 0);
            var lastPosition = GetCursorPosition();
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (lastPosition != GetCursorPosition())
                {
                    Console.Beep();
					Beep(2000, 400);
                    lastPosition = GetCursorPosition();

                }
                
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePosition
        {
            public int X;
            public int Y;

            public static implicit operator Point(MousePosition Position)
            {
                return new Point(Position.X, Position.Y);
            }
        }


        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out MousePosition position);

        public static Point GetCursorPosition()
        {
            GetCursorPos(out var mousePosition);
            return mousePosition;
        }

        //Console Window Manage
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

    }
}

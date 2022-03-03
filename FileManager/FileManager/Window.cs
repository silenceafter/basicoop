using System;
namespace FileManager
{

    public class Window
    {
        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol+x, origRow+y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected static int origRow;
        protected static int origCol;
        public async void Show()
        {
            //две части экрана
            // Clear the screen, then save the top and left coordinates.
            Console.Clear();
            Console.WriteLine();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            //Console.WriteLine(Console.WindowWidth);
            Console.SetCursorPosition(0, 0);
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            // Draw the left side of a 5x5 rectangle, from top to bottom.
            WriteAt("+", 0, 0);
            for(int i = 1; i < windowHeight; i++)
            {
                WriteAt("|", 0, i);
            }            
            WriteAt("+", 0, windowWidth);

            Console.SetCursorPosition(0, 1);
            // Draw the bottom side, from left to right.
            for(int i = 1; i < windowWidth; i++)
            {
                WriteAt("-", 0, windowWidth);
            }

            // Draw the right side, from bottom to top.
            /*WriteAt("|", 4, 3);
            WriteAt("|", 4, 2);
            WriteAt("|", 4, 1);
            WriteAt("+", 4, 0);

            // Draw the top side, from right to left.
            WriteAt("-", 3, 0); // shortcut: WriteAt("---", 1, 0)
            WriteAt("-", 2, 0); // ...
            WriteAt("-", 1, 0); // ...
            */
        }
    }
}
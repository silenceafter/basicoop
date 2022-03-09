using System;
using System.IO;
namespace FileManager
{

    public class Window
    {
        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);//Console.SetCursorPosition(origCol+x, origRow+y);
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
        public void Show()
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
            //WriteAt("+", 0, 0);
            /*for(int i = 1; i < windowHeight; i++)
            {
                WriteAt("|", 0, i);
            }            
            WriteAt("+", 0, windowWidth);*/

            Console.SetCursorPosition(0, 0);
            Console.Write("+"); 
            //верхняя горизонтальная линия
            Console.SetCursorPosition(1, 0);           
            for(int i = 1; i < windowWidth - 1; i++)
            {
                WriteAt("-", i, 0);
            }
            Console.Write("+");

            //левая вертикальная граница
            Console.SetCursorPosition(1, 1);
            for(int i = 1; i < windowHeight - 1; i++)
            {
                WriteAt("|", 0, i);
            }
            Console.SetCursorPosition(0, windowHeight - 1);
            Console.Write("+"); 

            //нижняя горизонтальная граница
            for(int i = 1; i < windowWidth - 1; i++)
            {
                WriteAt("-", i, windowHeight - 1);
            }
            Console.Write("+");
            Console.SetCursorPosition(windowWidth - 1, 1);

            //правая вертильная граница
            for(int i = 1; i < windowHeight - 1; i++)
            {
                WriteAt("|", windowWidth - 1, i);
            }

            //разделить экран пополам
            Console.SetCursorPosition(windowWidth / 2, 0);
            for(int i = 1; i < windowHeight - 1; i++)
            {
                WriteAt("|", windowWidth / 2, i);
            }
            Console.ReadLine();
            
        }
    }
}
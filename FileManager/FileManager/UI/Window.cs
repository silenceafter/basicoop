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
            //Console.ReadLine();
        }

        public async void Show(string part, Drive drive)
        {
            int left = 2;//"L"
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            //
            if (part.ToUpper() == "R")
            {
                left += windowWidth / 2;                
            }

            WriteAt("111", 2, 2);
            WriteAt("222", 2, 3);
            WriteAt("333", 2, 4);

            //очистка экрана
            int j = 0;
            for(int i = 1; i < windowHeight - 1; i++)
            {
                for(j = 1; j < windowWidth / 2 - 1; j++)
                {
                    WriteAt(" ", j, i);    
                }            
            }

            WriteAt($"Диск { drive.Name }", 2, 2);
            var folders = drive.RootFolder.ChildFolders;
            var files = drive.RootFolder.ChildFiles;
            
            //folders            
            int row = 0;//номер строки
            j = 0;
            for(int i = 3; i < windowHeight - 1; i++)
            {
                if (j >= folders.Count)
                {
                    row = i;
                    break;
                }
                WriteAt(folders[j].Name, 2, i);                
                j++;
            }

            //files
            j = 0;
            for(int k = row; k < windowHeight - 1; k++)
            {
                if (j >= files.Count)
                {
                    break;
                }
                WriteAt(files[j].Name, 2, k);
                j++;
            }
            Console.ReadLine();
        }
    }
}
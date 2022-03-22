using System;
using System.IO;
namespace FileManager
{
    public class MainWindow : ConsoleWindow
    {
        public MainWindow(
            string Name,
            string Title,
            ConsoleColor BackgroundColor,
            ConsoleColor ForegroundColor,
            bool Fullscreen
            )
        {
            _Name = Name;
            _Title = Title;
            _Columns = GetColumns();
            _Rows = GetRows();
            _BackgroundColor = BackgroundColor;
            _ForegroundColor = ForegroundColor;
            _FullScreen = Fullscreen;
            //
            SetBackgroudColor();
            SetForegroundColor();
            SetTitle();
            //SetFullscreen(Fullscreen);
        }

        private string _Name;
        private string _Title;
        private int _Columns;
        private int _Rows;
        private ConsoleColor _BackgroundColor;
        private ConsoleColor _ForegroundColor;
        private bool _FullScreen;

        public override string Name 
        {
            get => _Name;
        }

        public override string Title
        {
            get => _Title;
            set => _Title = value;
        }

        public override int Columns
        {
            get => _Columns;
            set => _Columns = value;
        }

        public override int Rows
        {
            get => _Rows;
            set => _Rows = value;
        }

        public override ConsoleColor BackgroundColor
        {
            get => _BackgroundColor;
            set => _BackgroundColor = value;
        }

        public override ConsoleColor ForegroundColor
        {
            get => _ForegroundColor;
            set => _ForegroundColor = value;
        }

        public override bool FullScreen
        {
            get => _FullScreen;
            set => _FullScreen = value;
        }

        public int GetColumns()
        {
            //получить кол-во колонок окна консоли
            return Console.WindowWidth;
        }

        public int GetRows()
        {
            //получить кол-во строк окна консоли
            return Console.WindowHeight;
        }

        public void SetBackgroudColor()
        {
            Console.BackgroundColor = BackgroundColor;
        }

        public void SetForegroundColor()
        {
            Console.ForegroundColor = ForegroundColor;
        }

        public void SetFullscreen(bool fullscreen)
        {
            //
        }

        public void SetTitle()
        {
            Console.Title = Title;
        }

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

            //Console.WriteLine(Console.WindowWidth);
            Console.SetCursorPosition(0, 0);
            int windowWidth = Columns;//Console.WindowWidth;
            int windowHeight = Rows;//Console.WindowHeight;            
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

            //правая вертикальная граница
            for(int i = 1; i < windowHeight - 1; i++)
            {
                WriteAt("|", windowWidth - 1, i);
            }

            //разделить экран пополам
            /*Console.SetCursorPosition(windowWidth / 2, 0);
            for(int i = 1; i < windowHeight - 3; i++)
            {
                WriteAt("|", windowWidth / 2, i);
            }*/
            //Console.SetCursorPosition(windowWidth / 2, 0);
            for(int i = 1; i < windowHeight - 1; i++)
            {
                WriteAt("|", windowWidth / 2, i);
            }
            /*
            //нижняя горизонтальная граница для командной строки
            for(int i = 1; i < windowWidth - 1; i++)
            {
                WriteAt("-", i, windowHeight - 3);
            }*/
        }

        public void Show(string part, Drive drive)
        {
            int left = 2;//"L"
            int j = 0;
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            //
            if (part.ToUpper() == "L")
            {
                WriteAt("111", 2, 2);
                WriteAt("222", 2, 3);
                WriteAt("333", 2, 4);

                //очистка экрана
                j = 0;
                for(int i = 1; i < windowHeight - 3; i++)
                {
                    for(j = 1; j < windowWidth / 2 - 1; j++)
                    {
                        WriteAt(" ", j, i);//j    
                    }            
                }
            }

            if (part.ToUpper() == "R")
            {
                left += windowWidth / 2;

                //очистка экрана
                j = 0;
                for(int i = 1; i < windowHeight - 3; i++)
                {
                    for(j = windowWidth / 2 + 1; j < windowWidth - 1; j++)
                    {
                        WriteAt(" ", j, i);//j    
                    }            
                }           
            }            

            WriteAt($"Диск { drive.Name }", left, 2);
            var folders = drive.RootFolder.ChildFolders;
            var files = drive.RootFolder.ChildFiles;

            //вмещается ли список директорий + файлов на экран -> вывести стрелку
            if (folders.Count + files.Count > windowHeight - 3)
            {
                //не вмещаются в экран
                //стрелка вверх
                WriteAt("\\", windowWidth / 2 - 3, windowHeight - 4);
                WriteAt("/", windowWidth / 2 - 2, windowHeight - 4);

                //стрелка вниз
                WriteAt("/", windowWidth / 2 - 3, 2);
                WriteAt("\\", windowWidth / 2 - 2, 2);
            }
            else 
            {
                //вмещается в экран
                //стрелка вверх
                WriteAt(" ", windowWidth / 2 - 3, windowHeight - 4);
                WriteAt(" ", windowWidth / 2 - 2, windowHeight - 4);

                //стрелка вниз
                WriteAt(" ", windowWidth / 2 - 3, 2);
                WriteAt(" ", windowWidth / 2 - 2, 2);                
            }
            
            //folders            
            int row = 0;//номер строки
            j = 0;
            for(int i = 3; i < windowHeight - 3; i++)
            {
                if (j >= folders.Count)
                {
                    row = i;
                    break;
                }
                WriteAt(folders[j].Name, left, i);                
                j++;
            }

            //files
            j = 0;
            for(int k = row; k < windowHeight - 3; k++)
            {
                if (j >= files.Count)
                {
                    break;
                }
                WriteAt(files[j].Name, left, k);
                j++;
            }
            //Console.ReadLine();
        }

        public void Command()
        {
            int windowHeight = Console.WindowHeight;
            Console.SetCursorPosition(2, windowHeight - 2);
            Console.Write("Команда: ");
            //
            string? command = Console.ReadLine();
            //получили команду -> обработка
        }
    }
}
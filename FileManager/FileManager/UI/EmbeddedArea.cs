using System;
using System.IO;
namespace FileManager
{
    public class EmbeddedArea : WindowArea
    {
        //окно для вывода информации
        public EmbeddedArea(
            string Name, 
            string Side, 
            int Left,
            int Top,
            int Height,
            int Width,
            MainWindow Parent
            )
        {
            _Name = Name;
            _Side = Side;
            _Left = Left;
            _Top = Top;
            _Height = Height;
            _Width = Width;
            _Parent = Parent;
        }

        private string _Name;
        private string _Side;
        private int _Left;
        private int _Top;
        private int _Height;
        private int _Width;
        private MainWindow _Parent;

        public override string Name
        {
            get => _Name;
        }

        public string Side
        {
            get => _Side;
        }

        public override int Left
        {
            get => _Left;
            set => _Left = value;
        }

        public override int Top
        {
            get => _Top;
            set => _Top = value;
        }

        public override int Height
        {
            get => _Height;
            set => _Height = value;
        }

        public override int Width
        {
            get => _Width;
            set => _Height = value;
        }

        public MainWindow Parent
        {
            get => _Parent;
        }

        public static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void Show()
        {
            //стереть наполнение внутри области
            for(int j = Top; j < Top + Height; j++)
            {
                for(int i = Left; i < Width - 1; i++)
                {
                    WriteAt(" ", i, j);
                }                
            }

            //верхняя горизонтальная линия
            /*for(int i = Left; i < Width - 1; i++)
            {
                WriteAt("-", i, Top);
            }

            //текст
            Console.SetCursorPosition(Left + 1, Top + 1);
            for(int i = Left + 1, j = 0; i < Width - 1 && j < Keys.Count; i++, j++)
            {                
                Console.Write($"{ j + 1 } { Keys[j] } ");
                var coordinates = Console.GetCursorPosition();
                Console.SetCursorPosition(coordinates.Left + 1, coordinates.Top);
            }*/
        }

        public void Show(Drive drive)
        {
            int left = Left;
            int j = 0;
            int windowWidth = Width;
            int windowHeight = Height;
            //
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
    }
}
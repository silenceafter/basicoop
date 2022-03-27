using System;
using System.IO;
namespace FileManager
{
    public class HelpArea : WindowArea
    {
        //коммандная строка внизу экрана
        public HelpArea(
            string Name,  
            int Left,
            int Top,
            int Height,
            int Width,
            MainWindow Parent
            )
        {
            _Name = Name;
            _Left = Left;
            _Top = Top;
            _Height = Height;
            _Width = Width;
            _Parent = Parent;
            _Keys = new List<Commands>();
        }

        private string _Name;
        private int _Left;
        private int _Top;
        private int _Height;
        private int _Width;
        private MainWindow _Parent;
        private List<Commands> _Keys;

        public List<Commands> Keys
        {
            get => _Keys;
            set => _Keys = value;
        }

        public override string Name
        {
            get => _Name;
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
            set => _Width = value;
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
            for(int i = Left; i < Width - 1; i++)
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
            }
        }
    }
}
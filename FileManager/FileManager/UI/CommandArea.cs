using System;
using System.IO;
namespace FileManager
{
    public class CommandArea : WindowArea
    {
        public CommandArea(
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
        }

        private string _Name;
        private int _Left;
        private int _Top;
        private int _Height;
        private int _Width;
        private MainWindow _Parent;

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
            for(int i = Left; i < Width - 1; i++)
            {
                for(int j = Top; j < Height - 1; j++)
                {
                    WriteAt(" ", i, j);
                }                
            }
        }
    }
}
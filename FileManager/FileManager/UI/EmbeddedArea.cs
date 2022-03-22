using System;
using System.IO;
namespace FileManager
{
    public class EmbeddedArea : WindowArea
    {
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
    }
}
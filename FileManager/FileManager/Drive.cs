namespace FileManager
{
    public class Drive
    {
        public Drive(
            string Name,
            Computer Parent,
            string FileSystem,
            bool System,
            int Size,
            int Used
        )
        {
            _Name = Name;
            _Parent = Parent;
            _FileSystem = FileSystem;
            _System = System;
            _Size = Size;
            _Used = Used;
        }

        private string _Name;
        private Computer _Parent;
        private string _FileSystem;
        private bool _System;
        private int _Size;
        private int _Used;

        public string Name
        {
            get => _Name;
        }

        public Computer Parent
        {
            get => _Parent;
        }

        public string FileSystem
        {
            get => _FileSystem;
        }

        public bool System
        {
            get => _System;
        }

        public int Size
        {
            get => _Size;
        }

        public int Used
        {
            get => _Used;
        }
    }
}
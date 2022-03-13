using System.IO;

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
            int Used,
            int Type
        )
        {
            _Name = Name;
            _Parent = Parent;
            _FileSystem = FileSystem;
            _System = System;
            _Size = Size;
            _Used = Used;

            //добавление корневой папки
            AddRootFolder();
        }

        private string _Name;
        private Computer _Parent;
        private Folder _RootFolder;
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

        public Folder RootFolder
        {
            get => _RootFolder;
            set => _RootFolder = value;
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

        public void AddRootFolder() 
        {
            //current directory
            var current = new DirectoryInfo(Name);
            //получить имя диска текущей директории
            var root = current.Root;
            var rootName = root.Name.Trim().ToLower();

            //объект текущей папки Folder
            RootFolder = new Folder(
                current.FullName, 
                this,
                null,
                new List<Folder>(), 
                new List<CFile>(), 
                current.Attributes.ToString(), 
                1000, 
                DateTime.Now);
            RootFolder.Scan();
        }   

        public bool FindDrive(DirectoryInfo drive)
        {
            //сравниваем путь 
            if (Name.Trim().ToLower() == drive.Name.Trim().ToLower())
            {
                return true;
            }
            return false;
        }
    }
}
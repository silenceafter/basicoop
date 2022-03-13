using System.IO;
namespace FileManager
{
    public class FileSystem
    {
        public FileSystem()
        {
            _Name = Environment.OSVersion.ToString();
            _Type = GetSystemType();
            //
            _Computers = new List<Computer>();
            _Computers.Add(new Computer(true, this));//добавить этот компьютер           
        }

        private string _Name;
        private int _Type;
        private List<Computer> _Computers;
        private FileSystem _Parent;

        public string Name
        {
            get => _Name;
        }

        public int Type
        {
            get => _Type;
        }

        public List<Computer> Computers
        {
            get => _Computers;
        }

        public FileSystem Parent
        {
            get => _Parent;
        }

        public void Create()
        {
            //создать файловую систему (TreeObject -> FileSystem)
            /*var computers = Computers;
            if (computers.Count > 0) {
                var userMachine = computers[0];
            }*/           
        }

        public string? GetSystemDriveByDefault()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }

        public int GetSystemType()
        {
            string currentOS = Name.Trim().ToLower();
            if (currentOS.Contains("windows"))
            {
                //windows
                return 1;
            }

            if(currentOS.Contains("unix") || currentOS.Contains("linux")) {
                //linux (в системе нет понятия диск, эту сущность не используем)
                return 2;
            }
            return 0;
        }

        public void GetFileSystemTree()
        {
            //
        }

        public Computer? GetUserMachine()
        {
            Computer Computer = null;
            if (Computers.Count > 0)
            {
                //компьютер пользователя
                Computer = Computers[0];
                foreach(var CComputer in Computers)
                {
                    if (Computer.IsUserMachine)
                    {
                        return Computer;
                    }
                }
            }
            return null;
        }

        public void Add(string path)
        {
            //добавить путь в дерево
        }
    }
}
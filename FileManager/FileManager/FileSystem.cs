using System.IO;

namespace FileManager
{
    public class FileSystem : ICSystem
    {
        public FileSystem()
        {
            _Name = Environment.OSVersion.ToString();
            _Computers = new List<Computer>();
            _Computers.Add(new Computer(true));//добавить этот компьютер
            
        }

        private string _Name;
        private List<Computer> _Computers;

        public string Name
        {
            get => _Name;
        }

        public List<Computer> Computers
        {
            get => _Computers;
        }

        public void Create()
        {
            //создать файловую систему (TreeObject -> FileSystem)
            var computers = Computers;
            if (computers.Count > 0) {
                var userMachine = computers[0];
                userMachine.AddDrives();
            }            
        }

        public string? GetSystemDriveByDefault()
        {
            return Path.GetPathRoot(Environment.SystemDirectory);
        }

        public void GetFileSystemTree()
        {
            //
        }
    }
}
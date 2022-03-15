using System.IO;
namespace FileManager
{
    public class CFileSystem : FileSystem
    {
        public CFileSystem()
        {
            _Name = Environment.OSVersion.ToString();
            _Type = GetSystemType();
            _ChildComputers = new List<Computer>();
        }

        private string _Name;
        private int _Type;
        private List<Computer> _ChildComputers;

        public override string Name 
        { 
            get => _Name;
        }
        public override int Type 
        { 
            get => _Type;
        }

        public List<Computer> ChildComputers
        {
            get => _ChildComputers;
            set => _ChildComputers = value;
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
    }
}
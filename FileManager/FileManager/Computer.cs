namespace FileManager
{
    public class Computer
    {
        public Computer(bool IsUserMachine)
        {
            _Name = Environment.MachineName;
            _IsUserMachine = IsUserMachine;
            _Drives = new List<Drive>();
        }

        private string _Name;
        private bool _IsUserMachine;
        private List<Drive> _Drives;

        public string Name 
        {
            get => _Name;
        }

        public bool IsUserMachine
        {
            get => _IsUserMachine;
        }

        public List<Drive> Drives
        {
            get => _Drives;
        }

        public void AddDrives()
        {
            
        }
        
    }
}
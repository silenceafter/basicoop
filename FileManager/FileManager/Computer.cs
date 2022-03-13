namespace FileManager
{
    public class Computer
    {
        public Computer(bool IsUserMachine, FileSystem Parent)
        {
            _Name = Environment.MachineName;
            _Parent = Parent;
            _IsUserMachine = IsUserMachine;
            _Drives = new List<Drive>();

            //windows/linux
            if (Parent.Type == 1) 
            {
                AddDrivesW();
            } else if (Parent.Type == 2)
            {
                AddDrivesL();
            } else {
                //throw new Exception(ArgumentOutOfRangeException);
            }          
        }

        private string _Name;
        private FileSystem _Parent;
        private bool _IsUserMachine;
        private List<Drive> _Drives;

        public string Name 
        {
            get => _Name;
        }

        public FileSystem Parent
        {
            get => _Parent;
        }

        public bool IsUserMachine
        {
            get => _IsUserMachine;
        }

        public List<Drive> Drives
        {
            get => _Drives;
        }

        public void AddDrivesW()
        {
            //windows
            var drives = DriveInfo.GetDrives();
            for(int i = 0; i < drives.Length; i++) 
            {
                _Drives.Add(new Drive(
                    drives[i].Name,
                    this,
                    drives[i].DriveFormat,
                    false,
                    (int)drives[i].TotalSize,
                    (int)drives[i].TotalFreeSpace,
                    1
                ));
            }                       
        }
        
        public void AddDrivesL()
        {
            //linux (в системе нет понятия диск, эта сущность используется упрщенно и при выводе на экран игнорируется)
            _Drives.Add(new Drive(
                "/",
                this,
                "system",
                false,
                0,
                0,
                2
            ));
        }

        public Drive? GetDriveByDefault()
        {
            //диск по умолчанию
            foreach(var Drive in Drives)
            {
                if (Drive.System) 
                {
                    return Drive;
                }
            }
            return null;
        }

        public Drive? FindDrive(DirectoryInfo drive)
        {
            //ищем диск, который совпадает с искомым
            for(int i = 0; i < Drives.Count; i++)
                {                  
                    if (Drives[i] != null)
                    {
                        if (Drives[i].Name.Trim().ToLower() == drive.Name.Trim().ToLower())
                        {
                            return Drives[i];
                        } 
                    }                                                                                   
                }            
            return null;
        }
    }
}
namespace FileManager
{
    public class Computer : Device
    {
        public Computer(bool IsUserMachine, CFileSystem Parent)
        {
            _Name = Environment.MachineName;
            _IsUserMachine = IsUserMachine;
            _Parent = Parent;
            //
            _ChildDrives = new List<Drive>();
            //
            if (_Parent.Type == 1)
            {
                //windows
                string path = GetSystemDriveByDefault();
                AddDrivesW();
            }
            else 
            {
                //linux
                AddDrivesL();
            }
        }

        private string _Name;
        private bool _IsUserMachine;
        private CFileSystem _Parent;
        private List<Drive> _ChildDrives;

        public override string Name 
        { 
            get => _Name; 
        }
        public override bool IsUserMachine 
        { 
            get => _IsUserMachine; 
        }

        public CFileSystem Parent
        {
            get => _Parent;
            set => _Parent = value;
        }

        public List<Drive> ChildDrives
        {
            get => _ChildDrives;
            set => _ChildDrives = value;
        }

        public string GetSystemDriveByDefault()
        {
            var path = Path.GetPathRoot(Environment.SystemDirectory);
            if (path != null)
            {
                return path;
            } 
            else 
            {
                //не можем определить системный диск/проблема чтения
                throw new Exception();
            }
        }

        public void AddDrivesW()
        {
            //windows
            var drives = DriveInfo.GetDrives();
            for(int i = 0; i < drives.Length; i++) 
            {
                if (drives[i].IsReady) {
                    _ChildDrives.Add(new Drive(
                        drives[i].Name,
                        drives[i].DriveFormat,
                        (int)drives[i].TotalSize,
                        DateTime.Now,
                        this
                    ));
                }                
            }                       
        }
        
        public void AddDrivesL()
        {
            //linux (в системе нет понятия диск, эта сущность используется упрщенно и при выводе на экран игнорируется)
            _ChildDrives.Add(new Drive(
                "/",
                "system",
                1000,
                DateTime.Now,
                this
            ));
        }

        public Drive? FindDrive(DirectoryInfo drive)
        {
            //ищем диск, который совпадает с искомым
            for(int i = 0; i < ChildDrives.Count; i++)
                {                  
                    if (ChildDrives[i] != null)
                    {
                        if (ChildDrives[i].Name.Trim().ToUpper() == drive.Name.Trim().ToUpper())
                        {
                            return ChildDrives[i];
                        } 
                    }                                                                                   
                }            
            return null;
        }
    }
    /*public class Computer
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
    }*/
}
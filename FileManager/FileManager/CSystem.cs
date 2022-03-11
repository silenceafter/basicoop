using System.IO;
namespace FileManager
{
    public class CSystem
    {
        public CSystem() 
        {
            _FileSystem = new FileSystem();
            
        }

        private FileSystem _FileSystem;

        public FileSystem FileSystem
        {
            get => _FileSystem;
        }

        public string ScanPath(string path)
        {
            //сканировать путь, который отправляет ui
            //определим, существует ли такой путь в дереве или нет
            DirectoryInfo dinfo = new DirectoryInfo(path);
            List<DirectoryInfo> folders = new List<DirectoryInfo>();
            
            //директории из строки для поиска в дереве
            var current = dinfo;
            while (current != null)
            {
                folders.Add(current);
                current = current.Parent;
            }

            //fileSystem -> userMachine
            var fileSystem = FileSystem;
            Computer? userMachine = fileSystem.GetUserMachine();
            //
            if (userMachine != null)
            {
                List<Drive>? Drives = userMachine.Drives;
                for(int i = 0; i < Drives.Count; i++)
                {
                    for(int j = 0; j < folders.Count; j++)
                    {
                        var Drive = Drives[i];
                        if (Drive != null) 
                        {
                            if (Drive.Name.Trim().ToLower() == folders[j].Name.Trim().ToLower())
                            {
                                int hh = 5;
                            } 
                        }                           
                    }
                    
                }
            }
            return "";
        }     
    }
}
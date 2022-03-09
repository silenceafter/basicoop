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

        public string? GetSystemDriveByDefault()
        {
            return "";
        }

        public string ScanPath(string path)
        {
            //сканировать путь, который отправляет ui
            //определим, существует ли такой путь в дереве или нет
            DirectoryInfo dinfo = new DirectoryInfo(path);
            
            return "";
        }     
    }
}
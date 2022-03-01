using System.IO;

namespace FileManager
{
    interface ICSystem
    {
        public string? GetSystemDriveByDefault();    
        public void GetFileSystemTree();        
    }
}
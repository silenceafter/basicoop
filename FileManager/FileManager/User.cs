using System.IO;

namespace FileManager
{
    public class User
    {
        public User()
        {
            _FolderByDefault = GetSystemDriveByDefault();
        }

        private string _FolderByDefault;

        public string FolderByDefault
        {
            get => _FolderByDefault;
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
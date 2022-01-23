using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class SystemOptions
    {
        public string GetSystemDriveByDefault()
        {
            //вернуть имя системного диска
            return "";
        }

        public FileSystem GetFileSystemTree()
        {
            //вернуть бинарное дерево
            var systemDrive = GetSystemDriveByDefault();
            var fileSystem = new FileSystem("UserPC", null, null);
            return fileSystem;
        }
    }
}

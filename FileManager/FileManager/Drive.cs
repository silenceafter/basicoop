using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Drive
    {
        public Drive (
            string Name, 
            Computer Computer, 
            string FileSystem, 
            bool System, 
            int Size, 
            int Used
            )
        {
            _Name = Name;
            _Parent = Computer;
            Folders = new List<Folder>();
            this.FileSystem = FileSystem;
            this.System = System;
            this.Size = Size;
            this.Used = Used;         
        }

        private string _Name;
        private Computer _Parent;
        public List<Folder> Folders { get; }
        public string FileSystem { get; }
        public bool System { get; }
        public int Size { get; }
        public int Used { get; }

        public bool AddFolder(Folder Folder)
        {
            return true;
        }

        public bool RemoveFolder(int FolderId)
        {
            return true;
        }

        public Folder GetElement(int FolderId)
        {
            return null;
        }

        public List<Folder> GetElementAll()
        {
            return null;
        }

        public Computer GetParent()
        {
            return null;
        }
    }
}

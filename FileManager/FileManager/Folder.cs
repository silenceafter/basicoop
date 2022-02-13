using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Folder
    {
        public Folder(
            string Name, 
            Drive Drive,
            bool Hidden, 
            bool ReadOnly, 
            int Size, 
            DateTime Date
            )
        {
            _Name = Name;
            _Parent = Drive;
            Files = new List<File>();
            this.Hidden = Hidden;
            this.ReadOnly = ReadOnly;
            this.Size = Size;
            this.Date = Date;
        }

        private string _Name;
        private Drive _Parent;
        public List<File> Files { get; }
        public bool Hidden { get; }
        public bool ReadOnly { get; }
        public int Size { get; }
        public DateTime Date { get; }

        public bool AddFile(File File)
        {
            return true;
        }

        public bool RemoveFile(int FileId)
        {
            return true;
        }

        public File GetElement(int FileId)
        {
            return null;
        }

        public List<File> GetElementAll()
        {
            return null;
        }

        public Folder GetParent()
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Computer
    {
        public Computer(string Name, FileSystem FileSystem)
        {
            _Name = Name;
            _Parent = FileSystem;
            this.Drives = new List<Drive>();
        }

        private string _Name;
        private FileSystem _Parent;
        public List<Drive> Drives { get; }

        public bool AddDrive(Drive Drive)
        {
            return true;
        }

        public bool RemoveDrive(int DriveId)
        {
            return true;
        }

        public Drive GetElement(int DriveId)
        {
            return null;
        }

        public List<Drive> GetElementAll()
        {
            return new List<Drive>();
        }

        public FileSystem GetParent()
        {
            return null;
        }
    }
}

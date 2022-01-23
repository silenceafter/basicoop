using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Network
    {
        public Network(string Name, FileSystem FileSystem) 
        {
            _Name = Name;
            _Parent = FileSystem;
            this.Computers = new List<Computer>();
        }

        private string _Name;
        private FileSystem _Parent;
        public List<Computer> Computers { get; }

        public  bool AddComputer(Computer Computer)
        {
            return true;
        }

        public bool RemoveComputer(int ComputerId)
        {
            return true;
        }

        public Computer GetElement(int ComputerId)
        {
            return null;
        }

        public List<Computer> GetElementAll()
        {
            return new List<Computer>();
        }

        public FileSystem GetParent()
        {
            return null;
        }
    }
}

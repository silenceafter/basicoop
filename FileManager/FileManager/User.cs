using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class User
    {
        public User(string Name)
        {
            _Name = Name;
            this.FolderByDefault = GetFolderByDefault();
            this.Computer = Create();
        }

        private string _Name;
        public string FolderByDefault { get; private set; }
        public Computer Computer { get; }

        public Computer Create()
        {
            //создать объект компьютера пользователя
            return null;
        }

        public string GetFolderByDefault()
        {
            //вернуть папку, из которой запускается программа (либо другая, по умолчанию)
            return this.FolderByDefault;
        }
    }
}

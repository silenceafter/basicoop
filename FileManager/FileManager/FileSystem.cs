using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileSystem
    {  
        public FileSystem(
            string Name, 
            Computer Computer,
            Network Network
            )
        {
            _Name = Name;
            _Parent = null;
            this.Computer = Computer;
            this.Network = Network;
            var myObject = Create();
        }

        private string _Name;
        private FileSystem _Parent;
        public Computer Computer { get; }//ссылка на компьютер пользователя
        public Network Network { get; }//ссылка на объект "Сеть"

        public FileSystem Create()
        {
            //создать бинарное дерево
            return null;
        }

        public bool Remove()
        {
            //удалить текущее дерево объектов
            return true;
        }

        public bool AddComputer(Computer Computer)
        {
            return true;
        }

        public bool RemoveComputer(int ComputerId)
        {
            return true;
        }

        public bool AddNetwork(Network Network)
        {
            return true;
        }

        public bool RemoveNetwork(int NetworkId)
        {
            return true;
        }
        public FileSystem GetParent()
        {
            return null;
        }
    }
}

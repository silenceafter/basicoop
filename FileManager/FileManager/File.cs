using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class File
    {
        public File(
            string Name,
            Folder Folder,
            bool Hidden,
            bool ReadOnly,
            int Size,
            DateTime Date
            )
        {
            _Name = Name;
            _Parent = Folder;
            this.Hidden = Hidden;
            this.ReadOnly = ReadOnly;
            this.Size = Size;
            this.Date = Date;
        }

        private string _Name;
        private Folder _Parent;
        public bool Hidden { get; }
        public bool ReadOnly { get; }
        public int Size { get; }
        public DateTime Date { get; }

        public Folder GetParent()
        {
            return null;
        }
    }
}

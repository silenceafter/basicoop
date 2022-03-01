using System.Collections;
namespace FileManager
{
    public class CFile
    {
        public CFile(
            string Name,
            Folder Parent,
            string Attributes,
            bool Hidden,
            bool ReadOnly,
            int Size,
            DateTime Date
        ) 
        {
            _Name = Name;
            _Parent = Parent;
            _Attributes = Attributes;
            _Hidden = Hidden;
            _ReadOnly = ReadOnly;
            _Size = Size;
            _Date = Date;
        }

        private string _Name;
        private Folder _Parent;
        private string _Attributes;
        private bool _Hidden;
        private bool _ReadOnly;
        private int _Size;
        private DateTime _Date;

        public string Name 
        {
            get => _Name;
        }

        public Folder Parent
        {
            get => _Parent;
        }

        public string Attributes
        {
            get => _Attributes;
        }

        public bool Hidden
        {
            get => _Hidden;
        }

        public bool ReadOnly
        {
            get => _ReadOnly;
        }

        public int Size
        {
            get => _Size;
        }

        public Folder GetParent()
        {
            return null;
        }
    }
}
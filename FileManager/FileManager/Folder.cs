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
            //_Files = new IEnumerable<File>();
            _Hidden = Hidden;
            _ReadOnly = ReadOnly;
            _Size = Size;
            _Date = Date;
        }

        private string _Name;
        private Drive _Parent;
        //public IEnumerable<File> _Files;
        private bool _Hidden;
        private bool _ReadOnly;
        private int _Size;
        private DateTime _Date;

        public string Name 
        {
            get => _Name;
        }

        public Drive Parent
        {
            get => _Parent;
        }

        /*public IEnumerable<FileManager.File> Files 
        {
            get => _Files;
        }*/

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

        public DateTime Date
        {
            get => _Date;
        }

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
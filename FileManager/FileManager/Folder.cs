using System.IO;
namespace FileManager
{
    public class Folder
    {
        public Folder(
            string Name, 
            Drive Drive,
            Folder Parent,
            List<Folder> Folders,
            List<CFile> CFiles,
            string Attributes,
            int Size, 
            DateTime Date
            )
        {
            _Name = Name;
            _Drive = Drive;
            _Parent = Parent;
            _Folders = new List<Folder>();
            _CFiles = new List<CFile>();
            //_Files = new IEnumerable<File>();
            _Attributes = Attributes;
            _Size = Size;
            _Date = Date;
        }

        private string _Name;
        private Drive _Drive;
        private Folder _Parent;
        private List<Folder> _Folders;
        private List<CFile> _CFiles;
        //public IEnumerable<File> _Files;
        private string _Attributes;
        private int _Size;
        private DateTime _Date;    

        public string Name 
        {
            get => _Name;
        }

        public Drive Drive
        {
            get => _Drive;
        }

        public Folder Parent
        {
            get => _Parent;
        }

        public List<Folder> Folders
        {
            get => _Folders;
        }

        public List<CFile> CFiles
        {
            get => _CFiles;
        }

        public string Attributes
        {
            get => _Attributes;
        }        

        public int Size
        {
            get => _Size;
        }

        public DateTime Date
        {
            get => _Date;
        }

        /*public void Add(FileManager.File NFile)
        {            
            _Files.Add(NFile); 
        }

        public void Add(FileManager.Folder Folder)
        {
            //
        }

        public void RemoveFile(int FileId)
        {
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
        }*/

        /*public bool CreateObjectTree(string Path, Drive ParentDrive, Folder ParentFolder)
        {
            var current = new DirectoryInfo(Path);
            var directories = current.GetDirectories();
            var files = current.GetFiles();
            //
            var folder = new Folder(
                current.FullName, 
                null,
                null, 
                current.Attributes.ToString(), 
                1000, 
                DateTime.Now);

for(int i = 0; i <= MyMain.Pagination; i++)
{
    directories = current.GetDirectories();
    files = current.GetFiles();
    //
    foreach(var directory in directories)
    {
        folder.Add(new Folder(
            directory.FullName, 
            null, 
            current,
            directory.Attributes.ToString(), 
            1000, 
            DateTime.Now));
    }
}
            return true;
        }*/
    }
}
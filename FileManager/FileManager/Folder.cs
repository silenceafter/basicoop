using System.IO;
namespace FileManager
{
    public class Folder : FileSystemObject
    {
        public Folder(
            string Name,
            string Attributes,
            int Size,
            DateTime Date,
            Folder? Parent
        )
        {
            _Name = Name;
            _Attributes = Attributes;
            _Size = Size;
            _Date = Date;
            _Parent = Parent;
            _ChildFolders = new List<Folder>();
            _ChildFiles = new List<CFile>();
        }

        private string _Name;
        private string _Attributes = "";
        private int _Size;
        private DateTime _Date;
        private Folder? _Parent;
        private List<Folder> _ChildFolders;
        private List<CFile> _ChildFiles;

        public override string Name 
        { 
            get => _Name; 
        }

        public override string Attributes 
        { 
            get => _Attributes;
        }

        public override int Size
        { 
            get => _Size; 
        }
        
        public override DateTime Date 
        { 
            get => _Date; 
        }

        public Folder? Parent
        {
            get => _Parent;
            set => _Parent = value;
        }

        public List<Folder> ChildFolders
        {
            get => _ChildFolders;
            set => _ChildFolders = value;
        }

        public List<CFile> ChildFiles
        {
            get => _ChildFiles;
            set => _ChildFiles = value;
        }
    }

    /*public class Folder
    {
        public Folder(
            string Name, 
            Drive Drive,
            Folder Parent,
            List<Folder> Folders,
            List<CFile> Files,
            string Attributes,
            int Size, 
            DateTime Date
            )
        {
            _Name = Name;
            _Drive = Drive;
            _Parent = Parent;
            _Folders = Folders;//new List<Folder>();
            _Files = Files;//new List<CFile>();
            //_Files = new IEnumerable<File>();
            _Attributes = Attributes;
            _Size = Size;
            _Date = Date;
        }

        private string _Name;
        private Drive _Drive;
        private Folder _Parent;
        private List<Folder> _Folders;
        private List<CFile> _Files;
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
            set => _Folders = value;
        }

        public List<CFile> Files
        {
            get => _Files;
            set => _Files = value;
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

        public void Scan()
        {
            //directories
            var current = new DirectoryInfo(Name);
            var directories = current.GetDirectories();            
            Folders = new List<Folder>();            

            //files
            var files = current.GetFiles();
            Files = new List<CFile>();
            //
            for(int i = 0; i < directories.Length; i++) 
            {
                Folders.Add(new Folder(
                    directories[i].FullName,
                    Drive,
                    this,
                    null,
                    null,
                    directories[i].ToString(), 
                    1000, 
                    DateTime.Now
                ));
            }

            for(int i = 0; i < files.Length; i++)
            {
                Files.Add(new CFile(
                    files[i].FullName,
                    this,
                    files[i].Attributes.ToString(),
                    false,
                    false,
                    1000,
                    DateTime.Now
                ));
            }
        }

        public Folder? FindFolder(DirectoryInfo folder)
        {
            foreach(var Current in Folders)
            {
                //сравниваем путь 
                if (Current.Name.Trim().ToLower() == folder.FullName.Trim().ToLower())
                {
                    return Current;
                }
            }            
            return null;
        }

        public CFile? FindFile(DirectoryInfo file)
        {
            foreach(var Current in Files)
            {
                //сравниваем путь 
                if (Current.Name.Trim().ToLower() == file.FullName.Trim().ToLower())
                {
                    return Current;
                }
            }            
            return null;
        }

        public Folder? Add(DirectoryInfo folder)
        {
            var current = new Folder(
                    folder.Name, 
                    Drive, 
                    Parent, 
                    new List<Folder>(), 
                    new List<CFile>(), 
                    "", 
                    1000,
                    DateTime.Now);
            Folders.Add(current);
            return current;
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
        }
    }*/
}
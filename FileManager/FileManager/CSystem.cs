using System.IO;
namespace FileManager
{
    public class CSystem
    {
        public CSystem() 
        {
            _FileSystem = new CFileSystem();
            
        }

        private CFileSystem _FileSystem;

        public CFileSystem FileSystem
        {
            get => _FileSystem;
        }

        public string ScanPath(string path)
        {
            //сканировать путь, который отправляет ui
            //определим, существует ли такой путь в дереве или нет
            DirectoryInfo dinfo = new DirectoryInfo(path);
            List<DirectoryInfo> folders = new List<DirectoryInfo>();
            bool isDirectory = false;
            
            //директория из строки в список
            var current = dinfo;
            while (current != null)
            {
                folders.Add(current);
                current = current.Parent;
            }

            //директория или файл?
            if (folders.Count > 0) 
            {
                var attribute = folders[0].Attributes;
                if (attribute.HasFlag(FileAttributes.Directory))
                {
                    //директория
                    isDirectory = true;
                }
            }

            //fileSystem -> userMachine
            var fileSystem = FileSystem;
            Computer? userMachine = fileSystem.GetUserMachine();
            //
            if (userMachine != null)
            {
                var currentDrive = userMachine.FindDrive(folders[folders.Count - 1]);
                if (currentDrive != null)
                {
                    //диск найден
                    if (folders.Count > 1)
                    {
                        //есть вложенные папки
                        Folder? currentFolder = currentDrive.RootFolder;
                        for(int i = folders.Count - 2; i > 0; i--)
                        {
                            var attribute = folders[i].Attributes;
                            if (attribute.HasFlag(FileAttributes.Directory))
                            {
                                //папка
                                Folder? response = currentFolder.FindFolder(folders[i]);
                                if (currentFolder != null)
                                {
                                    //папка найдена
                                    currentFolder = response;
                                    
                                }
                                else 
                                {
                                    //добавить папку
                                    
                                    break;
                                }
                            }
                            else 
                            {
                                //файл
                                CFile? currentFile = currentFolder.FindFile(folders[i]);
                                if (currentFile != null)
                                {

                                }
                                else 
                                {
                                    break;
                                }
                            }

                            
                        }                                                
                    }
                }

                /*Drive? currentDrive = null;
                List<Drive>? Drives = userMachine.Drives;
                for(int i = 0; i < Drives.Count; i++)
                {                  
                    if (Drives[i] != null)
                    {
                        if (Drives[i].FindDrive(folders[folders.Count - 1]))
                        {
                            //диск найден
                            currentDrive = Drives[i];
                            break;
                        }
                    }                                                                                   
                }*/
            }
            return "";
        }     
    }
}
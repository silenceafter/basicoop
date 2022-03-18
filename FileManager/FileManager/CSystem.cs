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

        public void ScanPath(string path)
        {
            //сканировать путь, который отправляет ui
            //определим, существует ли такой путь в дереве или нет
            DirectoryInfo dinfo = new DirectoryInfo(path);
            List<DirectoryInfo> folders = new List<DirectoryInfo>();
            
            //директория из строки в список
            var current = dinfo;
            while (current != null)
            {
                folders.Add(current);
                current = current.Parent;
            }

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
                        Folder currentFolder = currentDrive.RootFolder;
                        for(int i = folders.Count - 2; i >= 0; i--)
                        {
                            var attribute = folders[i].Attributes;
                            if (attribute.HasFlag(FileAttributes.Directory))
                            {
                                //папка
                                var response = currentFolder.FindFolder(folders[i]);
                                //папка найдена
                                if (response is Folder responseNotNull)
                                {
                                    currentFolder = responseNotNull;
                                } else 
                                {
                                    //добавить папку
                                    currentFolder = currentFolder.AddFolder(folders[i]);
                                }
                            }
                            else 
                            {
                                //файл
                                CFile? currentFile = currentFolder.FindFile(folders[i]);
                                if (currentFile == null)
                                {
                                    //добавить файл
                                    currentFolder.AddFile(folders[i]);
                                    return;
                                }
                            }                            
                        }                                                
                    }
                }            
            }
        }     
    }
}
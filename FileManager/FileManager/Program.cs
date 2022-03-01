using System.IO;
using FileManager;

//var gg = new FileManager.File();
var current = new DirectoryInfo("/");
//var bb = current.Attributes;
var directories = current.GetDirectories();
var files = current.GetFiles();

var folder = new Folder(
    current.FullName, 
    null, 
    null, 
    new List<Folder>(), 
    new List<CFile>(), 
    current.Attributes.ToString(), 
    1000, 
    DateTime.Now);

for(int i = 0; i <= MyMain.Pagination; i++)
{
    //directories
    directories = current.GetDirectories();
    if (directories.Length > 0) 
    {
        folder.Folders = new List<Folder>();
    }

    //files
    files = current.GetFiles();
    if (files.Length > 0) 
    {
        folder.Files = new List<CFile>();
    }
    //
    for(int j = 0; j <= directories.Length; j++) 
    {
        folder.Folders.Add(new Folder(
            directories[j].FullName,
            null,
            folder,
            null,
            null,
            directories[j].ToString(), 
            1000, 
            DateTime.Now
        ));
    }

    for(int j = 0; j <= files.Length; j++)
    {
        folder.Files.Add(new CFile(
            files[j].FullName,
            folder,
            false,
            false,
            1000,
            DateTime.Now
        ));
    }
}

/*List<Folder> folders = new List<Folder>();
foreach(var directory in directories)
{
    var folder = new Folder(directory.FullName, null, false, false, 1000, DateTime.Now);
    var file = directory.GetFiles();
    folders.Add(folder);
}*/

var tt = 55;
public static class MyMain
{
    private static int _Pagination;

    public static int Pagination
    {
        get => _Pagination;
        set => _Pagination = value;
    }
}


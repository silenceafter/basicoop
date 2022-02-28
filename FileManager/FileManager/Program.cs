using System.IO;
using FileManager;

//var gg = new FileManager.File();
var current = new DirectoryInfo("/");
//var bb = current.Attributes;
var directories = current.GetDirectories();
var files = current.GetFiles();

var folder = new Folder(current.FullName, null, current.Attributes.ToString(), 1000, DateTime.Now);
string currentDirectory = "/";
for(int i = 0; i <= MyMain.Pagination; i++)
{
    directories = current.GetDirectories();
    files = current.GetFiles();
    //
    for(int j = 0; j <= directories.Length; j++) 
    {
        //current.
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


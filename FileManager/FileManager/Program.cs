using System.IO;
using FileManager;

var cSystem = new CSystem();
var fileSystem = cSystem.FileSystem;
cSystem.ScanPath("D:\\");
//cSystem.ScanPath("/home/lenovo/Документы/vscode/");
//cSystem.ScanPath("C:\\FOXPRO2\\M10870_NSI\\M10870.DBF");
//cSystem.ScanPath("/home/lenovo/Документы/vscode/homeWork2/homeWork2.sln");
var window = new MainWindow("MainWindow", "FileManager | v0.1", ConsoleColor.DarkBlue, ConsoleColor.White, false);
var left_area = new EmbeddedArea("EmbeddedAreaLeft", "Left", 1, 1, window.Rows - 6, window.Columns / 2, window);
var right_area = new EmbeddedArea("EmbeddedAreaRight", "Right", window.Columns / 2 + 1, 1, window.Rows - 6, window.Columns, window);
var command = new CommandArea("CommandArea", 1, window.Rows - 3, 2, window.Columns, window);
var help = new HelpArea("HelpArea", 1, window.Rows - 5, 2, window.Columns, window);
//
help.Keys.Add(Commands.Help);
help.Keys.Add(Commands.Menu);
help.Keys.Add(Commands.View);
help.Keys.Add(Commands.Edit);
help.Keys.Add(Commands.Copy);
help.Keys.Add(Commands.Move);
help.Keys.Add(Commands.NewFolder);
help.Keys.Add(Commands.Delete);
help.Keys.Add(Commands.Exit);
//var left = new EmbeddedWindow("LeftWindow", "LEFT", 1, 1, window.Columns / )
window.Show();
left_area.Show();
right_area.Show();
command.Show();
help.Show();

left_area.Show(fileSystem.ChildComputers[0].ChildDrives[0]);
right_area.Show(fileSystem.ChildComputers[0].ChildDrives[1]);
//window.Show("L", fileSystem.ChildComputers[0].ChildDrives[0]);
//window.Show("R", fileSystem.ChildComputers[0].ChildDrives[1]);
//window.Command();
Console.ReadKey();
//drives
/*var system =  Path.GetPathRoot(Environment.SystemDirectory);//var bb = System.Environment.GetEnvironmentVariable("WINDIR");
var drives = DriveInfo.GetDrives();
//
List<Drive> drivesList = new List<Drive>();
    for(int i = 0; i < drives.Length; i++)
    {
        drivesList.Add(new Drive(
            drives[i].Name,
            null,
            drives[i].DriveFormat,
            false,
            (int)drives[i].TotalSize,
            (int)drives[i].TotalFreeSpace
        )); 
    }
    
//current directory
var currentDirectory = Directory.GetCurrentDirectory();
var current = new DirectoryInfo(currentDirectory);
//получить имя диска текущей директории
var root = current.Root;
var rootName = root.Name.Trim().ToLower();

//найти объект Drive текущего диска
Drive currentDrive = null;
for(int i = 0; i < drivesList.Count; i++)
{
    if (drivesList[i].Name.Trim().ToLower() == rootName)
    {
        currentDrive = drivesList[i];
        break;
    }    
}

if (currentDrive != null)
{
    //объект диска найден
    var directories = current.GetDirectories();
    var files = current.GetFiles();

    //объект текущей папки Folder
    var folder = new Folder(
        current.FullName, 
        currentDrive, 
        null,
        new List<Folder>(), 
        new List<CFile>(), 
        current.Attributes.ToString(), 
        1000, 
        DateTime.Now);

    //for(int i = 0; i <= MyMain.Pagination; i++)
    //{
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
        for(int j = 0; j < directories.Length; j++) 
        {
            folder.Folders.Add(new Folder(
                directories[j].FullName,
                currentDrive,
                folder,
                null,
                null,
                directories[j].ToString(), 
                1000, 
                DateTime.Now
            ));
        }

        for(int j = 0; j < files.Length; j++)
        {
            folder.Files.Add(new CFile(
                files[j].FullName,
                folder,
                files[j].Attributes.ToString(),
                false,
                false,
                1000,
                DateTime.Now
            ));
        }
    //}
}*/



public static class MyMain
{
    private static int _Pagination;

    public static int Pagination
    {
        get => _Pagination;
        set => _Pagination = value;
    }
}

public enum Commands {
    Help,
    Menu,
    View,
    Edit,
    Copy,
    Move,
    NewFolder,
    Delete,
    Exit
};


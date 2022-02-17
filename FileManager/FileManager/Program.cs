// See https://aka.ms/new-console-template for more information
using FileManager;
//
//создаем объект User и Computer (через конструктор пользователя)
var user = new User("User1");
var system = new SystemOptions();//"системный" объект, с методами, который запускают основные действия программы
var fileSystem = system.GetFileSystemTree();//создать дерево файловой системы

//выводим на экран дерево файловой системы, показываем параметры файлов, папок, дисков и т.д.
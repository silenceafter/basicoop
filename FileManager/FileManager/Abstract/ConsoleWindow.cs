using System.IO;
namespace FileManager
{
    public abstract class ConsoleWindow
    {
        public abstract string Name { get; }
        public abstract string Title { get; set; }
        public abstract int Columns { get; set; }
        public abstract int Rows { get; set; }
        public abstract ConsoleColor BackgroundColor { get; set; }
        public abstract ConsoleColor ForegroundColor { get; set; }
        public abstract bool FullScreen { get; set; }
    }
}
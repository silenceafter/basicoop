using System.IO;
namespace FileManager
{
    public abstract class WindowArea
    {
        public abstract string Name { get; }
        public abstract int Left { get; set; }
        public abstract int Top { get; set; }
        public abstract int Height { get; set; }
        public abstract int Width { get; set; }
    }
}
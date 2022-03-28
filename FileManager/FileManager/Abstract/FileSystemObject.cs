namespace FileManager
{
    public abstract class FileSystemObject
    {
        public abstract string Name { get; }
        public abstract string Attributes { get; }
        public abstract int Size { get; }
        public abstract DateTime Date { get; }
    }
}
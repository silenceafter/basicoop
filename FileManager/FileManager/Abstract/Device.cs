namespace FileManager
{
    public abstract class Device
    {
        public abstract string Name { get; }
        public abstract bool IsUserMachine { get; }
    }
}
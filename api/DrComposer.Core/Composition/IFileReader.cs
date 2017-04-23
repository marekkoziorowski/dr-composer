namespace DrComposer.Core.Composition
{
    public interface IFileReader
    {
        bool Exists(string path);
        string ReadAllText(string path);
    }
}

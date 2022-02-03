//задание 3
var textFile = new TextFile("sample.txt");
Console.ReadKey();

public class TextFile
{
    public TextFile(string filename) 
    {
        Filename = filename;
    }

    private string _filename = "";
    public string Filename
    {
        get => _filename;
        set => _filename = value;
    }

    public string SearchMail(ref string s)
    {
        return "";
    }
}
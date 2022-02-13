using System.IO;

//задание 3
var textFile = new TextFile("sample.txt");
if (textFile != null)
{
    textFile.Read();
    Console.WriteLine($"Файл { textFile.InputFile } создан");
    Console.WriteLine("Чтение файла");
    //
    textFile.Search();
    Console.WriteLine("Поиск e-mail адресов в тексте");
    //
    textFile.Write();
    Console.WriteLine($"Запись файла { textFile.EmailFile }");
    Console.WriteLine("Готово");
}
Console.ReadLine();

public class TextFile
{
    public TextFile(string filename) 
    {
        InputFile = filename;
        EmailFile = "email.txt";
        FileByRows = new List<string>();
    }

    public List<string> FileByRows { get; set; }
    public List<string> NewFileByRows { get; set; }
    public string InputFile { get; private set; }
    public string EmailFile { get; private set; }
    public FileStream MyTextFile { get; private set; }
    public FileStream Email { get; private set; }

    public void Read()
    {  
        using (StreamReader sr = new StreamReader(new BufferedStream(File.OpenRead(InputFile), 1024 * 1024), System.Text.Encoding.Default))
        {
            //выделим буфер в 1 Мб
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] rows = line.Split('&');
                foreach(var row in rows) {
                    FileByRows.Add(row);
                }                
            }
        }                   
    }

    public void Search()
    {
        NewFileByRows = new List<string>();
        for (int i = 0; i < this.FileByRows.Count; i++)
        {
            //выделим email из строки
            var s = this.FileByRows[i];
            this.SearchMail(ref s);
            NewFileByRows.Add(s);
        }
    }

    public void SearchMail(ref string s)
    {
        //выделить из строки адрес почты
        string[] tmpArray = s.Split(' ');
        //
        foreach(string tmp in tmpArray)
        {
            if (tmp.Contains('@'))
            {
                //email обнаружен
                s = tmp;
                break;
            }
        }
    }

    public void Write()
    {
        //проверим существование файла
        if (File.Exists(EmailFile))
        {
            File.Delete(EmailFile);
        }

        for (int i = 0; i < NewFileByRows.Count; i++)
        {
            var s = NewFileByRows[i];
            if (s.Contains('@'))
            {
                WriteEmail(s);
            }                
        }
    }

    public void WriteEmail(string s)
    {
        // запись в файл
        using (StreamWriter sw = new StreamWriter(EmailFile, true, System.Text.Encoding.Default))
        {
           sw.WriteLine(s);
        }        
    }
}
using System.IO;

//задание 3
var textFile = new TextFile("sample.txt");
if (textFile != null)
{
    textFile.Read();
    Console.WriteLine($"Файл { textFile.InputFile } создан");
    Console.WriteLine("Чтение файла");
    textFile.Search();
    Console.WriteLine("Поиск e-mail адресов в тексте");
    textFile.Write();
    Console.WriteLine($"Запись файла { textFile.EmailFile }");
    Console.WriteLine("Готово");
}
Console.ReadKey();

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
        using var fstream = File.OpenRead(InputFile);
        if (fstream != null)
        {
            byte[] array = new byte[fstream.Length];//преобразуем строку в байты            
            fstream.Read(array, 0, array.Length);//считываем данные            
            string text = System.Text.Encoding.Default.GetString(array);//декодируем байты в строку
                                                                        //
            string[] rows = text.Split('&');
            for (var i = 0; i < rows.Length; i++)
            {
                string s = rows[i];
                FileByRows.Add(rows[i]);
            }
        }
        //ВОПРОС: Если при чтении возникнет ошибка, как лучше поступить с обработкой ошибки, учитывая, что у нас есть using
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
                WriteEmail(ref s);
            }                
        }
    }

    public void WriteEmail(ref string s)
    {
        // запись в файл
        using var fstream = new FileStream(EmailFile, FileMode.Append);
        if (fstream != null)
        {
            // преобразуем строку в байты
            byte[] array = System.Text.Encoding.Default.GetBytes($"{ s }\n");
            // запись массива байтов в файл
            fstream.Write(array, 0, array.Length);
        }
    }
}
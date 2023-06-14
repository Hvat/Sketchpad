namespace Sketchpad.Models;

internal class Note
{
    public string Filename { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public void Save() =>
       File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);

    public void Delete() =>
        File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

    public Note()
    {
        Filename = $"{Path.GetRandomFileName()}.notes.txt";
        Date = DateTime.Now;
        Text = "";
    }

    public static Note Load(string filename)
    {
        filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

        if (!File.Exists(filename))
            throw new FileNotFoundException("Не удалось найти файл в локальном хранилище.", filename);

        return
            new()
            {
                Filename = Path.GetFileName(filename),
                Text = File.ReadAllText(filename),
                Date = File.GetLastWriteTime(filename)
            };
    }

    public static IEnumerable<Note> LoadAll()
    {
        // Получить папку, в которой хранятся заметки
        string appDataPath = FileSystem.AppDataDirectory;

        // Используйте расширения Linq для загрузки файлов *.notes.txt
        return Directory

                // Выберите имена файлов из каталога
                .EnumerateFiles(appDataPath, "*.notes.txt")

                // Каждое имя файла используется для загрузки заметки
                .Select(filename => Note.Load(Path.GetFileName(filename)))

                // При окончательном сборе заметок упорядочить их по дате
                .OrderByDescending(note => note.Date);
    }
}

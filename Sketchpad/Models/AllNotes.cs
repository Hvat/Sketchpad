using System.Collections.ObjectModel;

namespace Sketchpad.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

    public AllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Получить папку, в которой хранятся заметки.
        string appDataPath = FileSystem.AppDataDirectory;

        // Используйте расширения Linq для загрузки файлов *.notes.txt.
        IEnumerable<Note> notes = Directory

                                    // Выберите имена файлов из каталога
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Каждое имя файла используется для создания новой заметки.
                                    .Select(filename => new Note()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetLastWriteTime(filename)
                                    })

                                    // При окончательном сборе заметок упорядочить их по дате
                                    .OrderBy(note => note.Date);

        // Добавьте каждую заметку в ObservableCollection
        foreach (Note note in notes)
            Notes.Add(note);
    }
}
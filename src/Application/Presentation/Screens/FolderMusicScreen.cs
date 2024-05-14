using play_sharp.Presentation.Interfaces;
using System.Text;

namespace play_sharp.Presentation.Screens;
public class FolderMusicScreen : IScreen
{
    public List<MusicFolder> Folders { get; set; } = [];
    public MusicFolder CurrentFolder { get; set; }
    public MusicFile? CurrentMusic { get; set; }
    public int CurrentMusicDisplayIndex { get; set; }

    const int FolderWindowHeight = Constants.WindowHeight - 5;
    const int MusicWindowHeight = Constants.WindowHeight - 5;

    public FolderMusicScreen()
    {
    }

    public void RefreshScreen()
    {
        var sb = new StringBuilder();

        var folderDisplayLength = 34;
        var musicDisplayLength = 64;

        var title = "Artist                             Track";

        sb.AppendLine(title);

        for (int i = 0; i < FolderWindowHeight; i++)
        {
            var folder = Folders.ElementAtOrDefault(i).DisplayName ?? string.Empty;
            var music = CurrentFolder.MusicFiles?.ElementAtOrDefault(i).DisplayName ?? string.Empty;

            if (folder.Length > folderDisplayLength)
                folder = folder[0..folderDisplayLength];
            else
                folder = folder.PadRight(folderDisplayLength, ' ');

            if (music.Length > musicDisplayLength)
                music = music[0..musicDisplayLength];
            else
                music = music.PadRight(musicDisplayLength, ' ');

            sb.Append(folder);
            sb.Append('|');
            sb.AppendLine(music);
        }

        var currentFolderName = CurrentFolder.DisplayName;

        if (currentFolderName != null)
        {
            if (currentFolderName.Length > folderDisplayLength)
                currentFolderName = CurrentFolder.DisplayName[0..folderDisplayLength];
        }
        else
        {
            currentFolderName = "N/A";
        }

        var currentMusic = CurrentMusic?.DisplayName;
        if (currentMusic != null)
        {
            if (currentMusic.Length > musicDisplayLength)
                currentMusic = CurrentMusic?.DisplayName[0..musicDisplayLength];
        }
        else
        {
            currentMusic = "N/A";
        }

        sb.Append(currentFolderName);
        sb.Append(" - ");
        sb.AppendLine(currentMusic);
        sb.AppendLine("> 00:05 / 2:06 - vol: 083");

        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(sb.ToString());

        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(title.PadRight(Constants.WindowWidth, ' '));

        if (CurrentMusic != null)
        {
            Console.CursorTop = CurrentMusicDisplayIndex + 1;
            Console.CursorLeft = folderDisplayLength + 1;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(currentMusic);
        }

        Console.CursorTop = Constants.WindowHeight - 4;
        Console.CursorLeft = 0;
        Console.BackgroundColor = ConsoleColor.DarkGray;
        var playingMusic = currentFolderName + " - " + currentMusic;
        Console.WriteLine(playingMusic.PadRight(Constants.WindowWidth, ' '));

        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        var random = new Random().NextInt64(0, 100).ToString().PadLeft(3, '0');
        var playingMusicTime = $"> 00:05 / 2:06 - vol: {random}".PadRight(Constants.WindowWidth, ' ');
        Console.WriteLine(playingMusicTime);
    }

    public void LoadFiles(string directory)
    {
        directory = directory.Trim('\0');

        var directories = Directory.GetDirectories(directory);

        var rootFiles = new List<MusicFile>();

        rootFiles.AddRange(GetMusicFiles(directory));

        CurrentFolder = new MusicFolder("root", rootFiles);

        Folders.Add(CurrentFolder);

        foreach (var dir in directories)
        {
            var files = new List<MusicFile>();

            files.AddRange(GetMusicFiles(dir));

            rootFiles.AddRange(files);

            Folders.Add(new MusicFolder(dir, files));
        }
    }

    private static IEnumerable<MusicFile> GetMusicFiles(string directory)
        => Directory.GetFiles(directory)
            .Where(c => c.EndsWith(".mp3") || c.EndsWith(".wav"))
            .Select(c => new MusicFile(c));
}

public struct MusicFile(string directory)
{
    public string Directory { get; set; } = directory;
    public string DisplayName { get; set; } = directory?.Split('\\').LastOrDefault();
}

public struct MusicFolder(string directory, List<MusicFile> musicFiles)
{
    public string Directory { get; set; } = directory;
    public string DisplayName { get; set; } = directory?.Split('\\').LastOrDefault();
    public List<MusicFile> MusicFiles { get; set; } = musicFiles;
}
using play_sharp.Presentation.Enum;
using play_sharp.Presentation.Interfaces;

namespace play_sharp.Presentation;
public class InterfaceHandler : IInterfaceHandler
{
    private bool ShouldRefreshScreen = true;

    private Screen CurrentScreen = Screen.Text;
    private int TextCursorPosition = 2;
    public char[] CurrentText = new char[Constants.WindowWidth];

    private static object refreshLock = new object();

    public async Task HandleAsync(CancellationTokenSource cancellationTokenSource)
    {
        do
        {
            if (ShouldRefreshScreen)
            {
                lock (refreshLock)
                {
                    RefreshScreen();
                }
            }
                

            await Task.Delay(50);
        } while (!cancellationTokenSource.IsCancellationRequested);
    }

    private void RefreshScreen()
    {
        UpdateScreen();
        UpdateCursorPosition();
    }

    public void OnTabPressed(object sender, EventArgs args)
    {
        ShouldRefreshScreen = true;
    }

    public void OnKeyPressed(object sender, KeyPressedEventArgs args)
    {
        if (CurrentScreen == Screen.Text)
        {
            lock (refreshLock)
            {
                if (args.ConsoleKey.Key == ConsoleKey.Backspace)
                {
                    if (TextCursorPosition > 0)
                        TextCursorPosition--;

                    CurrentText[TextCursorPosition] = ' ';
                }
                else
                {
                    CurrentText[TextCursorPosition++] = args.Key;
                }
                
                RefreshScreen();
            }
        }
    }

    private void UpdateScreen()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;


        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Artist                             Track                                                            ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("Band 01                           |Album Name--------------------------------------------------43:29");
        Console.WriteLine("Band 02                           | 1. Music 1                                                  1:51");
        Console.WriteLine("                                  | 2. Music 2                                                  3:01");
        Console.Write("                                  |");

        Console.BackgroundColor = ConsoleColor.DarkBlue;

        Console.WriteLine(" 3. Music 3                                                  2:06                    ");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("                                  | 4. Music 4                                                  2:19");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.WriteLine("                                  |                                                                 ");
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Band 01 - Album Name - Music 1                                                                      ");
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        var random = new Random().NextInt64(0, 100).ToString().PadLeft(3, '0');

        Console.WriteLine($"> 00:05 / 2:06 - vol: {random}                                                                           ");

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"> {new string(CurrentText)}");

        ShouldRefreshScreen = false;
    }

    private void UpdateCursorPosition()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
    }
}

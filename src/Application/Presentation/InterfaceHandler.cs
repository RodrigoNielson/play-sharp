using play_sharp.Presentation.Interfaces;

namespace play_sharp.Presentation;
public class InterfaceHandler : IInterfaceHandler
{
    private bool RefreshScreen = true;

    public async Task HandleAsync(CancellationTokenSource cancellationTokenSource)
    {
        do
        {
            if (RefreshScreen)
            {
                UpdateScreen();
                UpdateCursorPosition();
            }


            await Task.Delay(50);
        } while (!cancellationTokenSource.IsCancellationRequested);
    }


    public void OnTabPressed(object sender, EventArgs args)
    {
        RefreshScreen = true;
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
        Console.WriteLine("                                  |                                                                 ");
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Band 01 - Album Name - Music 1                                                                      ");
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        var random = new Random().NextInt64(0, 100).ToString().PadLeft(3, '0');

        Console.WriteLine($"> 00:05 / 2:06 - vol: {random}                                                                           ");

        RefreshScreen = false;
    }

    private void UpdateCursorPosition()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
    }
}

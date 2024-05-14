﻿using play_sharp.Presentation.Interfaces;
using static play_sharp.Presentation.Delegates;

namespace play_sharp.Presentation;
public class InputHandler : IInputHandler
{
    public event EventHandler TabPressed;
    public event KeyPressed KeyPressed;

    public async Task HandleAsync(CancellationTokenSource cancellationTokenSource)
    {
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.Tab:
                    TabPressed?.Invoke(this, new EventArgs());
                    break;
                case ConsoleKey.RightArrow:
                    if (Console.CursorLeft < Console.WindowWidth - 1 && Console.CursorLeft < Constants.WindowWidth - 1)
                        Console.CursorLeft += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (Console.CursorLeft > 0)
                        Console.CursorLeft -= 1;
                    break;
                case ConsoleKey.UpArrow:
                    if (Console.CursorTop > 0)
                        Console.CursorTop -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (Console.CursorTop < Console.WindowHeight - 1 && Console.CursorTop < Constants.WindowHeight - 1)
                        Console.CursorTop += 1;
                    break;
                default:
                    KeyPressed?.Invoke(this, new KeyPressedEventArgs
                    {
                        Key = key.KeyChar,
                        ConsoleKey = key
                    });
                    break;
            }

        } while (true);
    }
}

public class KeyPressedEventArgs : EventArgs
{
    public char Key { get; set; }
    public ConsoleKeyInfo ConsoleKey { get; set; }
}
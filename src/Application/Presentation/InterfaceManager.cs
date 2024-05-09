using play_sharp.Presentation.Interfaces;

namespace play_sharp.Presentation;

public class InterfaceManager(IInputHandler inputHandler, IInterfaceHandler interfaceHandler)
{
    private readonly IInputHandler _inputHandler = inputHandler;
    private readonly IInterfaceHandler _interfaceHandler = interfaceHandler;

    public async Task RunAsync()
    {
        Console.SetWindowSize(Constants.WindowWidth, Constants.WindowHeight);

        var cancellationTokenSource = new CancellationTokenSource();

        cancellationTokenSource.Token.ThrowIfCancellationRequested();

        var interfaceTask = _interfaceHandler.HandleAsync(cancellationTokenSource);

        _inputHandler.TabPressed += _interfaceHandler.OnTabPressed;

        var inputTask = _inputHandler.HandleAsync(cancellationTokenSource);
        
        await Task.WhenAll(inputTask, interfaceTask);
    }
}

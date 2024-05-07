namespace play_sharp.Presentation.Interfaces;
public interface IInputHandler
{
    public event EventHandler TabPressed;
    Task HandleAsync(CancellationTokenSource cancellationTokenSource);
}

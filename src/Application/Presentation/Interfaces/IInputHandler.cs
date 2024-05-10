using static play_sharp.Presentation.Delegates;

namespace play_sharp.Presentation.Interfaces;
public interface IInputHandler
{
    public event EventHandler TabPressed;
    public event KeyPressed KeyPressed;
    Task HandleAsync(CancellationTokenSource cancellationTokenSource);
}

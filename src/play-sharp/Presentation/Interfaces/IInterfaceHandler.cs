namespace play_sharp.Presentation.Interfaces;
public interface IInterfaceHandler
{
    Task HandleAsync(CancellationTokenSource cancellationTokenSource);
    void OnTabPressed(object sender, EventArgs args);
}

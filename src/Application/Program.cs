using Microsoft.Extensions.DependencyInjection;
using play_sharp.Presentation;
using play_sharp.Presentation.Interfaces;

var serviceProvider = new ServiceCollection()
    .AddSingleton<InterfaceManager>()
    .AddSingleton<IInputHandler, InputHandler>()
    .AddSingleton<IInterfaceHandler, InterfaceHandler>()
    .BuildServiceProvider();

var interfaceHandler = serviceProvider.GetRequiredService<InterfaceManager>();

try
{
    await interfaceHandler.RunAsync();
}
catch (Exception ex)
{

}
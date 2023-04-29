using DesafioIntelitrader.Source;
using DesafioIntelitrader.Source.Application.Services;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
Directory.SetCurrentDirectory(projectDirectory);

var services = new ServiceCollection();

services.AddScoped<ITransferService, TransferService>();
services.AddScoped<IDivergencyService, DivergencyService>();
services.AddScoped<IChannelSaleService, ChannelSaleService>();
services.AddScoped<IReadFileService, ReadFileService>();

services.BuildServiceProvider();

var main = new Main();
main.Run();
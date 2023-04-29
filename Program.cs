using DesafioIntelitrader.Source;
using DesafioIntelitrader.Source.Application.Services;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
Directory.SetCurrentDirectory(projectDirectory);

var services = new ServiceCollection();

services.AddScoped<IProductService, ProductService>();
services.AddScoped<ISaleService, SaleService>();
services.AddScoped<ITransferService, TransferService>();
services.AddScoped<IDivergencyService, DivergencyService>();

services.BuildServiceProvider();

var main = 
    new Main(
        new TransferService(new SaleService(), new ProductService()),
        new DivergencyService(new SaleService(), new ProductService())
    );

main.Run();
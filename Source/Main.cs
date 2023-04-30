using DesafioIntelitrader.Source.Application.Services;
using DesafioIntelitrader.Source.UseCase;
using DesafioIntelitrader.Source.Domain.Entites;


namespace DesafioIntelitrader.Source
{
    class Main
    {
        public void Run()
        {

            var fileNames1 = new FileNameEntity
            {
                Product = "c1_produtos.txt",
                Sale = "c1_vendas.txt"
            };

            var fileNames2 = new FileNameEntity
            {
                Product = "c2_produtos.txt",
                Sale = "c2_vendas.txt"
            };

            var teste1 = new ProcessFileUseCase
                (
                    new ReadFileService(fileNames1, "Source/Files/teste1/"),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService(),
                    new WriteFileService("Source/Files/teste1/")
                );
            
            var teste2 = new ProcessFileUseCase
                (
                    new ReadFileService(fileNames2, "Source/Files/teste2/"),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService(),
                    new WriteFileService("Source/Files/teste2/")
                );
            
            teste1.Flow();
            teste2.Flow();
        }
    }
}

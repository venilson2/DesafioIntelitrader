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

            var teste1 = new ProcessFileUseCase
                (
                    new ReadFileService(fileNames1),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService(),
                    new WriteFileService()
                );
            /*
            var teste2 = new ProcessFileUseCase
                (
                    new ReadFileService(
                        "Source/Files/teste2/c2_produtos.txt", "Source/Files/teste2/c2_vendas.txt"),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService(),
                    new WriteFileService("Source/Files/teste2")
                );
            */
            teste1.Flow();
        }
    }
}

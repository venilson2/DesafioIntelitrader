using DesafioIntelitrader.Source.Application.Services;
using DesafioIntelitrader.Source.UseCase;

namespace DesafioIntelitrader.Source
{
    class Main
    {
        public void Run()
        {
            var teste1 = new ProcessFileUseCase
                (
                    new ReadFileService(
                        "Source/Files/teste1/c1_produtos.txt", "Source/Files/teste1/c1_vendas.txt"),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService()
                );

            var teste2 = new ProcessFileUseCase
                (
                    new ReadFileService(
                        "Source/Files/teste2/c2_produtos.txt", "Source/Files/teste2/c2_vendas.txt"),
                    new TransferService(),
                    new DivergencyService(),
                    new ChannelSaleService()
                );

            teste1.Flow();
            teste2.Flow();
        }
    }
}

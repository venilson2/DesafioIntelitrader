using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    internal interface IReadFileService
    {
        List<ProductEntity> ReadFileProduct();
        List<SaleEntity> ReadFileSale();
    }
}

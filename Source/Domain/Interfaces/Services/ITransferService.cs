using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    internal interface ITransferService
    {
        List<TransfereDTO> CalculateTransfere(List<ProductEntity> products, List<SaleEntity> sales);
    }
}

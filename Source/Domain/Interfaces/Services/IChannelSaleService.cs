using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    internal interface IChannelSaleService
    {
        List<TotalChannelSaleDTO> CalculateQuantityByChannelSale(List<SaleEntity> sales);
    }
}

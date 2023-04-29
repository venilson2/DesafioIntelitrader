using DesafioIntelitrader.Source.Domain.DTO;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    internal interface IChannelSaleService
    {
        List<TotalChannelSaleDTO> CalculateQuantityByChannelSale();
    }
}

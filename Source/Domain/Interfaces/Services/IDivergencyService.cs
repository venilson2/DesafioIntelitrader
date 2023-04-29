using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    interface IDivergencyService 
    {
        List<DivergencyDTO> CalculateDivergency(List<SaleEntity> sales, List<ProductEntity> products);
    }
}

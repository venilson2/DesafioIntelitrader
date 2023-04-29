using DesafioIntelitrader.Source.Domain.Entites;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    interface ISaleService : IService<SaleEntity>
    {
        List<IGrouping<int, SaleEntity>> GroupProductsByCode();
    }
}

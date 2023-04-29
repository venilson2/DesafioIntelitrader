using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class ChannelSaleService : IChannelSaleService
    {
        private readonly ISaleService _saleService;
        
        public ChannelSaleService(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public List<TotalChannelSaleDTO> CalculateQuantityByChannelSale()
        {
            List<SaleEntity> sales = _saleService.ReadFile();

            List<SaleEntity> salesFilredBySaleConfirmed = sales.Where(
                sale =>
                sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_ok ||
                sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_pendente
                )
                .ToList();

            var salesFilredBySaleConfirmedGroupped = salesFilredBySaleConfirmed.GroupBy(sale => sale.Canal_Venda).ToList();

            List<TotalChannelSaleDTO> totalChannelSales = salesFilredBySaleConfirmedGroupped
            .Select(group => new TotalChannelSaleDTO
            {
                Id = (int)group.Key,
                Name = group.Key.ToString(),
                Total = group.Sum(sale => sale.Qtd_Vendida)
            })
            .ToList();  

            return totalChannelSales;
        }
    }
}

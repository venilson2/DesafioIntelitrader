using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;
using DesafioIntelitrader.Source.Infraestructure.Extensions;

namespace DesafioIntelitrader.Source.Application.Services
{
    class ChannelSaleService : IChannelSaleService
    {
        public List<TotalChannelSaleDTO> CalculateQuantityByChannelSale(List<SaleEntity> sales)
        {
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
                Name = group.Key.ToDisplayName(),
                Total = group.Sum(sale => sale.Qtd_Vendida)
            })
            .ToList();  

            return totalChannelSales;
        }
    }
}

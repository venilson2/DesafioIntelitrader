using DesafioIntelitrader.Source.Domain.Enums;

namespace DesafioIntelitrader.Source.Domain.Entites
{
    internal class SaleEntity
    { 
        public int Cod_Produto { get; set; }
        public int Qtd_Vendida { get; set; }
        public SaleSituationEnum Situacao_Venda { get; set; }
        public SaleChannelEnum Canal_Venda { get; set; }




        public static List<SaleEntity> FilterBySaleSituation(List<SaleEntity> sales)
        {
            return sales.Where(sale => sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_ok
                || sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_pendente)
                .ToList();
        }
    }
}

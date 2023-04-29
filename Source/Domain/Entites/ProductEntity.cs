using DesafioIntelitrader.Source.Domain.Enums;

namespace DesafioIntelitrader.Source.Domain.Entites
{
    class ProductEntity
    {
        public int Cod_Produto { get; set; }
        public int Qtd_Estoque { get; set; }
        public int Qtd_Min_CO { get; set; }


        public int CalculateQtdVendas(List<IGrouping<int, SaleEntity>> salesGroupedByCode)
        {
            var productSales = salesGroupedByCode.FirstOrDefault(g => g.Key == Cod_Produto);

            var salesConfirmed = productSales.Where(sale =>
                sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_ok ||
                sale.Situacao_Venda == SaleSituationEnum.venda_confirmada_pagamento_pendente).ToList();

            var qtdVendas = salesConfirmed.Sum(x => x.Qtd_Vendida);

            return qtdVendas;
        }

        public int CalculateEstoqueAposVenda(int qtdVendas, int qtdCO)
        {
            int estoqueAposCenda = qtdCO - qtdVendas;

            return estoqueAposCenda;
        }
        public int CalculateNecessidades(int estoqAposVenda, int QtdMin)
        {
            var necessidade = QtdMin - estoqAposVenda;

            necessidade = necessidade < 0 ? 0 : necessidade;
            return necessidade;
        }

        internal int CalculateTransfArmazenamento(int qtdVendas, int nescessidade)
        {
            if (nescessidade <= 0)
            {
                return 0;
            }
            else if (nescessidade <= 10)
            {
                return 10;
            }
            else
            {
                return nescessidade;
            }

        }
    }
}

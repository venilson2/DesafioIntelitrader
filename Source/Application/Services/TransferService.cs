using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

class TransferService : ITransferService
{
    public List<TransfereDTO> CalculateTransfere(List<ProductEntity> products, List<SaleEntity> sales)
    {
        List<TransfereDTO> transfereList = new();
        List<IGrouping<int,SaleEntity>> salesGroupedByCode = sales.GroupBy(p => p.Cod_Produto).ToList();

        foreach (var product in products)
        {
            var qtdVendas = product.CalculateQtdVendas(salesGroupedByCode);
            var estoqVendas = product.CalculateEstoqueAposVenda(qtdVendas, product.Qtd_Estoque);
            var nescessidades = product.CalculateNecessidades(estoqVendas, product.Qtd_Min_CO);
            var transfArmazenPCO = product.CalculateTransfArmazenamento(qtdVendas, nescessidades);

            transfereList.Add(new TransfereDTO
            {
                Cod_Produto = product.Cod_Produto,
                Qtd_CO = product.Qtd_Estoque,
                Qtd_min = product.Qtd_Min_CO,
                Qtd_vendas = qtdVendas,
                Estoq_vendas = estoqVendas,
                Nescessidades = nescessidades,
                Tranf_armazen_p_CO = transfArmazenPCO
            });
        }

        return transfereList;
    }
    
}

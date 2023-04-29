using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

class TransferService : ITransferService
{
    private readonly ISaleService _saleService;
    private readonly IProductService _productService;

    public TransferService()
    {
    }

    public TransferService(ISaleService saleService, IProductService productService)
    {
        _saleService = saleService;
        _productService = productService;
    }


    public List<TransfereDTO> CalculateTransfere()
    {
        var sales = _saleService.ReadFile();
        var products = _productService.ReadFile();
        var salesGroupedByCode = _saleService.GroupProductsByCode();

        var transfereList = new List<TransfereDTO>();

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

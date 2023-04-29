using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class ReadFileService : IReadFileService
    {
        private readonly string _filePathProduct;
        private readonly string _filePathSale;

        public ReadFileService(string filePathSale, string filePathProduct)
        {
            _filePathProduct = filePathSale;
            _filePathSale = filePathProduct;
        }
        public List<ProductEntity> ReadFileProduct()
        {
            List<ProductEntity> products = File.ReadAllLines(_filePathProduct)
                .Select(line => line.Split(';'))
                .Select(columns => new ProductEntity
                {
                    Cod_Produto = int.Parse(columns[0]),
                    Qtd_Estoque = int.Parse(columns[1]),
                    Qtd_Min_CO = int.Parse(columns[2])
                })
                .ToList();
            return products;
        }

        public List<SaleEntity> ReadFileSale()
        {
            List<SaleEntity> sales = File.ReadAllLines(_filePathSale)
                 .Select(line => line.Split(";"))
                 .Select(columns => new SaleEntity
                 {
                     Cod_Produto = int.Parse(columns[0]),
                     Qtd_Vendida = int.Parse(columns[1]),
                     Situacao_Venda = (SaleSituationEnum)Enum.Parse(typeof(SaleSituationEnum), columns[2]),
                     Canal_Venda = (SaleChannelEnum)Enum.Parse(typeof(SaleChannelEnum), columns[3])
                 })
                 .ToList();

            return sales;
        }
    }
}

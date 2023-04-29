using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class SaleService : ISaleService
    {
        string filePath = "Source/Files/teste1/c1_vendas.txt";
        char delimiter = ';';

        public List<SaleEntity> ReadFile()
        {
            List<SaleEntity> sales = File.ReadAllLines(filePath)
                 .Select(line => line.Split(delimiter))
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

        public List<IGrouping<int, SaleEntity>> GroupProductsByCode()
        {
            List<SaleEntity> sales = this.ReadFile();
            var groupedProducts = sales.GroupBy(p => p.Cod_Produto);
            return groupedProducts.ToList();
        }
    }
}

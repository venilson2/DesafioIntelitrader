using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class ProductService : IProductService
    {

        string filePathPro = "Source/Files/teste1/c1_produtos.txt";
        char delimiter = ';';

        public List<ProductEntity> ReadFile()
        {
            List<ProductEntity> products = File.ReadAllLines(filePathPro)
                .Select(line => line.Split(delimiter))
                .Select(columns => new ProductEntity
                {
                    Cod_Produto = int.Parse(columns[0]),
                    Qtd_Estoque = int.Parse(columns[1]),
                    Qtd_Min_CO = int.Parse(columns[2])
                })
                .ToList();
            return products;
        }


    }
}

using DesafioIntelitrader.Source.Domain.Enums;

namespace DesafioIntelitrader.Source.Domain.Entites
{
    class SaleEntity
    { 
        public int Cod_Produto { get; set; }
        public int Qtd_Vendida { get; set; }
        public SaleSituationEnum Situacao_Venda { get; set; }
        public SaleChannelEnum Canal_Venda { get; set; }

        public bool VerifyCode(List<ProductEntity> products)
        {
            bool containCode = products.Any(product => product.Cod_Produto == this.Cod_Produto);

            if(containCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

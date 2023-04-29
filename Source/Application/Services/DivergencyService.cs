using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class DivergencyService : IDivergencyService
    {
        private readonly ISaleService _saleService;
        private readonly IProductService _productService;

        public DivergencyService(ISaleService saleService, IProductService productService)
        {
            _saleService = saleService;
            _productService = productService;
        }

        public List<string> CalculateDivergency()
        {
            List<SaleEntity> sales = _saleService.ReadFile();
            List<ProductEntity> products = _productService.ReadFile();

            var messages = new List<string>();
            int line = 1;

            foreach (var sale in sales)
            {
                if (sale.Situacao_Venda == SaleSituationEnum.venda_não_finalizada)
                {
                    messages.Add($"Linha {line} - Venda não finalizada");
                }
                else if (sale.Situacao_Venda == SaleSituationEnum.venda_cancelada)
                {
                    messages.Add($"Linha {line} - Venda Cancelada");
                }
                else if (sale.Situacao_Venda == SaleSituationEnum.erro_não_identificado)
                {
                    messages.Add($"Linha {line} - Erro desconhecido. Acionar equipe de TI");
                }
                else if (sale.VerifyCode(products))
                {
                    messages.Add($"Linha {line} - Código de Produto não encontrado {sale.Cod_Produto}");
                }
                line++;
            }

            return messages;
        }
    }
}

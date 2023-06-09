﻿using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Enums;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class DivergencyService : IDivergencyService
    {
        public List<DivergencyDTO> CalculateDivergency(List<SaleEntity> sales, List<ProductEntity> products)
        {
            var messages = new List<DivergencyDTO>();
            int line = 1;

            foreach (var sale in sales)
            {
                if (sale.Situacao_Venda == SaleSituationEnum.venda_não_finalizada)
                {
                    messages.Add(new DivergencyDTO { Line = line, Description = "Venda não finalizada" });
                }
                else if (sale.Situacao_Venda == SaleSituationEnum.venda_cancelada)
                {
                    messages.Add(new DivergencyDTO { Line = line, Description = "Venda Cancelada" });
                }
                else if (sale.Situacao_Venda == SaleSituationEnum.erro_não_identificado)
                {
                    messages.Add(new DivergencyDTO { Line = line, Description = "Erro desconhecido. Acionar equipe de TI" });
                }
                else if (sale.VerifyCode(products))
                {
                    messages.Add(new DivergencyDTO { Line = line, Description = $"Código de Produto não encontrado {sale.Cod_Produto}" });
                }
                line++;
            }

            return messages;
        }

    }
}

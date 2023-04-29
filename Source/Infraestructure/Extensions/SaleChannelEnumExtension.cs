using DesafioIntelitrader.Source.Domain.Enums;

namespace DesafioIntelitrader.Source.Infraestructure.Extensions
{
    static class SaleChannelEnumExtensions
    {
        public static string ToDisplayName(this SaleChannelEnum channel)
        {
            switch (channel)
            {
                case SaleChannelEnum.Representante_comercial:
                    return "Representante";
                case SaleChannelEnum.Website:
                    return "Website";
                case SaleChannelEnum.App_móvel_Android:
                    return "App móvel Android";
                case SaleChannelEnum.App_móvel_Iphone:
                    return "App móvel iPhone";
                default:
                    throw new ArgumentException("Canal de venda inválido");
            }
        }
    }

}

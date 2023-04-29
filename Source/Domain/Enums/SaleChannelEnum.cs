using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DesafioIntelitrader.Source.Domain.Enums
{
    enum SaleChannelEnum
    {
        [Display(Name = "Representante")]
        Representante_comercial = 1,
        [Display(Name = "Website")]
        Website = 2,
        [Display(Name = "App móvel Android")]
        App_móvel_Android = 3,
        [Display(Name = "App móvel iPhone")]
        App_móvel_Iphone = 4,
    }
}

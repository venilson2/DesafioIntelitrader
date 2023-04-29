using DesafioIntelitrader.Source.Domain.DTO;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    internal interface ITransferService
    {
        List<TransfereDTO> CalculateTransfere();
    }
}

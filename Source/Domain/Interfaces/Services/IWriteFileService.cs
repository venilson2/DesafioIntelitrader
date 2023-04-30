using DesafioIntelitrader.Source.Domain.DTO;

namespace DesafioIntelitrader.Source.Domain.Interfaces.Services
{
    interface IWriteFileService
    {
        void WriteFileTransfer(List<TransfereDTO> tranfereList);
        void WriteFileDivergency(List<DivergencyDTO> divergencyList);
        void WriteFileChannelSale(List<TotalChannelSaleDTO> totalChannelSaleList);
    }
}
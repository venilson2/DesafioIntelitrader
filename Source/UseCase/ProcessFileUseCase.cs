using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.UseCase
{
    internal class ProcessFileUseCase
    {
        private readonly IReadFileService _readFileService;
        private readonly ITransferService _transferService;
        private readonly IDivergencyService _divergencyService;
        private readonly IChannelSaleService _channelSaleService;

        public ProcessFileUseCase
        (
            IReadFileService readFileService,
            ITransferService tranferService, 
            IDivergencyService divergencyService, 
            IChannelSaleService channelSaleService 
        )
        {
            _readFileService = readFileService;
            _transferService = tranferService;
            _divergencyService = divergencyService;
            _channelSaleService = channelSaleService;
        }
        public void Flow()
        {
            List<ProductEntity> products = _readFileService.ReadFileProduct();
            List<SaleEntity> sales = _readFileService.ReadFileSale();
            List<TransfereDTO> tranfereList = _transferService.CalculateTransfere(products, sales);
            List<DivergencyDTO> divergencyList = _divergencyService.CalculateDivergency(sales, products);
            List<TotalChannelSaleDTO> channelSaleList = _channelSaleService.CalculateQuantityByChannelSale(sales);
        }
    }
}

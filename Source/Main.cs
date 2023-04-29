using DesafioIntelitrader.Source.Application.Services;
using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Entites;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace DesafioIntelitrader.Source
{
    class Main
    {
        private readonly ITransferService _transferService;
        private readonly IDivergencyService _divergencyService;
        private readonly IChannelSaleService _channelSaleService;
        public Main(ITransferService tranferService, IDivergencyService divergencyService, IChannelSaleService channelSaleService)
        {
            _transferService = tranferService;
            _divergencyService = divergencyService;
            _channelSaleService = channelSaleService;
        }

        public void Run()
        {

            List<TransfereDTO> tranfereList = _transferService.CalculateTransfere();
            List<DivergencyDTO> divergencyList = _divergencyService.CalculateDivergency();
            List<TotalChannelSaleDTO> channelSaleList = _channelSaleService.CalculateQuantityByChannelSale();
        }
    }
}

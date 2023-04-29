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
        public Main(ITransferService tranferService, IDivergencyService divergencyService)
        {
            _transferService = tranferService;
            _divergencyService = divergencyService;
        }
        
        public void Run()
        {

            List<TransfereDTO> tranfereList = _transferService.CalculateTransfere();
            List<string> divergencyList = _divergencyService.CalculateDivergency();

            Console.WriteLine("--- Tranfer ---");
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-15} | {5,-15} | {6,-15} |", "Produto", "QtCO", "QtMin", "QtVendas", "Estoq após venda", "Nescess.", "Trans");
            Console.WriteLine("+{0}{1}{2}{3}{4}{5}{6}+",
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+");
            foreach (var trans in tranfereList)
            {
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,-15}| {4,-15}| {5,-15}| {6,-15}", 
                    trans.Cod_Produto, 
                    trans.Qtd_CO, 
                    trans.Qtd_min, 
                    trans.Qtd_vendas, 
                    trans.Estoq_vendas, 
                    trans.Nescessidades, 
                    trans.Tranf_armazen_p_CO);
            }
            Console.WriteLine("+{0}{1}{2}{3}{4}{5}{6}+", 
                new string('-', 17), "+", 
                new string('-', 17), "+", 
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+",
                new string('-', 17), "+");
        }
    }
}

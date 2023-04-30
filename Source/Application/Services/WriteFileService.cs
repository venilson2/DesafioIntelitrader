using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class WriteFileService : IWriteFileService
    {
        private readonly string _filePath = "Source/Files/teste1/";
        
        public void WriteFileTransfer(List<TransfereDTO> tranfereList)
        {
            StreamWriter writer = new StreamWriter(_filePath + "c1_transfere.txt");

            writer.WriteLine("Necessidade de Transferência Armazém para CO\n");
            writer.WriteLine("{0,-10}    {1,-10}    {2,-10}    {3,-10}    {4,-10}    {5,-15}    {6,-20}",
                "Produtoo", "QtCO", "QtMin", "QtVendas", "Estoq.após Vendas", "Nescess.", "Tranf. de Arm p/ CO\n");

            foreach (var item in tranfereList)
            {
                string line = string.Format("{0,-10}    {1,-10}    {2,-10}    {3,-10}    {4,-10}            {5,-15}    {6,-20}",
                    item.Cod_Produto, item.Qtd_CO, item.Qtd_min, item.Qtd_vendas, item.Estoq_vendas, item.Nescessidades, item.Tranf_armazen_p_CO);

                writer.WriteLine(line);
            }

            writer.Close();
        }

        public void WriteFileDivergency(List<DivergencyDTO> divergencyList)
        {
            throw new NotImplementedException();
        }

        public void WriteFileChannelSale(List<TotalChannelSaleDTO> totalChannelSaleList)
        {
            throw new NotImplementedException();
        }
    }
}

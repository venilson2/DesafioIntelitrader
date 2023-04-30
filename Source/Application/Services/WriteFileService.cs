using DesafioIntelitrader.Source.Domain.DTO;
using DesafioIntelitrader.Source.Domain.Interfaces.Services;

namespace DesafioIntelitrader.Source.Application.Services
{
    class WriteFileService : IWriteFileService
    {
        private readonly string _filePath;
        public WriteFileService(string filePath) 
        {
            _filePath = filePath;
        }
        
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
            StreamWriter writer = new StreamWriter(_filePath + "c1_divergencias.txt");

            foreach (var item in divergencyList)
            {

                writer.WriteLine($"Linha {item.Line} - {item.Description}");
            }

            writer.Close();
        }

        public void WriteFileChannelSale(List<TotalChannelSaleDTO> totalChannelSaleList)
        {
            StreamWriter writer = new StreamWriter(_filePath + "c1_totcanal.txt");

            writer.WriteLine("Quantidades de Vendas por canal\n");
            writer.WriteLine("{0,-20} {1,10}",
                "Canal", "QtVendas");

            foreach (var item in totalChannelSaleList)
            {
                string line = string.Format("{0,-20} {1,10}",
                    $"{item.Id} - {item.Name}", item.Total.ToString());

                writer.WriteLine(line);
            }

            writer.Close();
        }

    }
}

using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Interfaces
{
    public interface ITransacao
    {
        List<TransacaoModel> ListaTransacoes(DateTime? dataInicial = null, DateTime? dataFinal = null);
        int Inserir(TransacaoModel form);
        void Editar(TransacaoModel form);
        void Excluir(int id);
        TransacaoModel CarregarTransacaoPorId(int? id);
    }
}

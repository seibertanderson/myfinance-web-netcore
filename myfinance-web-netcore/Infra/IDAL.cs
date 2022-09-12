using System.Data;

namespace myfinance_web_netcore.Infra
{
    public interface IDAL
    {
        bool Conectar();
        void Desconectar();
        DataTable RetornarDataTable(string sql);
        void ExecutarComandoSQL(string sql);
    }
}

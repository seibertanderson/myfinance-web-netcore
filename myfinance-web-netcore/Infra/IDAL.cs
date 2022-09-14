using System.Data;

namespace myfinance_web_netcore.Infra
{
    public interface IDAL
    {
        bool Conectar();
        void Desconectar();
        DataTable RetornarDataTable(string sql);
        int ExecutarComandoSQL(string sql);
    }
}

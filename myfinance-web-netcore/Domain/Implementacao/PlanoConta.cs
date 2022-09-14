using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_netcore.Domain.Interfaces;
using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Domain.Implementacao
{
    public class PlanoConta : IPlanoConta
    {
        public List<PlanoContaModel> ListaPlanoContas()
        {
            List<PlanoContaModel> lista = new List<PlanoContaModel>();
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = "SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS";
            var dataTable = objDal.RetornarDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                lista.Add(new PlanoContaModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["id"].ToString()),
                    Descricao = dataTable.Rows[i]["descricao"].ToString(),
                    Tipo = dataTable.Rows[i]["tipo"].ToString()
                });
            }
            objDal.Desconectar();
            return lista;
        }

        public IEnumerable<SelectListItem> ListaSelectItemPlanoContas()
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = "SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS";
            var dataTable = objDal.RetornarDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var planoConta = new SelectListItem()
                {
                    Text = dataTable.Rows[i]["descricao"].ToString(),
                    Value = dataTable.Rows[i]["id"].ToString()
                };
                lista.Add(planoConta);
            }
            objDal.Desconectar();
            return lista;
        }

        public PlanoContaModel CarregarPlanoContaPorId(int? id)
        {
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = $"SELECT ID, DESCRICAO, TIPO FROM PLANO_CONTAS WHERE ID = {id}";
            var dataTable = objDal.RetornarDataTable(sql);

            PlanoContaModel obj = new PlanoContaModel()
            {
                Id = int.Parse(dataTable.Rows[0]["id"].ToString()),
                Descricao = dataTable.Rows[0]["descricao"].ToString(),
                Tipo = dataTable.Rows[0]["tipo"].ToString()
            };

            objDal.Desconectar();
            return obj;
        }

        public void Inserir(PlanoContaModel model)
        {
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = $"INSERT INTO PLANO_CONTAS (DESCRICAO, TIPO) VALUES ('{model.Descricao}', '{model.Tipo}')";
            objDal.ExecutarComandoSQL(sql);
            objDal.Desconectar();

        }

        public void Editar(PlanoContaModel model)
        {
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = $@"UPDATE PLANO_CONTAS 
                         SET DESCRICAO = '{model.Descricao}',
                         TIPO = '{model.Tipo}'
                         WHERE ID = {model.Id} ";
            objDal.ExecutarComandoSQL(sql);
            objDal.Desconectar();

        }

        public void Excluir(int id)
        {
            var objDal = DAL.GetInstancia;
            objDal.Conectar();

            var sql = $"DELETE FROM PLANO_CONTAS WHERE ID = {id}";
            objDal.ExecutarComandoSQL(sql);
            objDal.Desconectar();
        }
    }
}

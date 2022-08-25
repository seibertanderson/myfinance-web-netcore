using System.Data;
using System.Data.SqlClient;

namespace myfinance_web_netcore.Infra
{
    public class DAL
    {
        private SqlConnection conn;
        private string connectionString;
        public static IConfiguration? configuration;
        private static DAL Instancia;

        public static DAL GetInstancia
        {
            get
            {
                if (Instancia == null) { Instancia = new(); }
                return Instancia;
            }
        }

        public DAL()
        {
            connectionString = configuration.GetValue<string>("ConnectionString");
        }

        public void Conectar()
        {
            conn = new();
            conn.ConnectionString = connectionString;
            conn.Open();
        }

        public void Desconectar()
        {
            conn.Close();
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable RetornarDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql , conn);
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="sql"></param>
        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

    }
}

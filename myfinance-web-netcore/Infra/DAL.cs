using System.Data;
using System.Data.SqlClient;

namespace myfinance_web_netcore.Infra
{
    public class DAL : IDAL
    {
        private SqlConnection conn;
        private string connectionString;
        public static IConfiguration? configuration;
        private static DAL? Instancia;

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

        public bool Conectar()
        {
            try
            {
                conn = new();
                conn.ConnectionString = connectionString;
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Desconectar()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// SELECT
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable RetornarDataTable(string sql)
        {
            var dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="sql"></param>
        public int ExecutarComandoSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

    }
}

using System.Data.SqlClient;
using System.Web.Configuration;

namespace RetoMok.ConexionDataBase
{
    public class ConexionData
    {
        public SqlConnection con;
        private SqlCommand cmd = new SqlCommand();

        public SqlConnection Conectar()
        {
            string Conexion = WebConfigurationManager.ConnectionStrings["ConexionModels"].ConnectionString.ToString();
            con = new SqlConnection(Conexion);

            return con;
        }
    }
}
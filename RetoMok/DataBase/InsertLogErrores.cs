using RetoMok.ConexionDataBase;
using RetoMok.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RetoMok.DataBase
{
    public class InsertLogErrores
    {
        LogErrores logErrores = new LogErrores();

        private SqlConnection con;

        private const string sql = @"INSERT INTO [dbo].[LogErrores]
           ([Descripcion] ,[pagina] ,[FechaCreacion])
            VALUES
           (@DESCRIPCION ,@PAGINA , @FECHACREACION)";

        public InsertLogErrores(LogErrores errores)
        {
            logErrores = errores;
        }

       

        public void InsertErrores()
        {
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();
            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = logErrores.Descripcion;
                comando.Parameters.Add("@PAGINA", SqlDbType.VarChar).Value = logErrores.Pagina;
                comando.Parameters.Add("@FECHACREACION", SqlDbType.DateTime).Value = DateTime.Now;
                comando.ExecuteNonQuery(); //execute the Query
                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using RetoMok.ConexionDataBase;
using RetoMok.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RetoMok.DataBase
{

    public class GetTiposDocumentos
    {
        private SqlConnection con;

        List<TipoDocumento> tipoDocumentos = new List<TipoDocumento>();

        private const string sql = @" SELECT [IdTipoDocumento] ,[Descripcion] ,[vigente]
                                        FROM [RetoMok].[PAR].[TipoDocumento]";

        public GetTiposDocumentos()
        {
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();
        }


        public List<TipoDocumento> Get()
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    tipoDocumentos.Add(new TipoDocumento
                    {
                        IdTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]),
                        Descripcion = Convert.ToString(dr["Descripcion"]),
                        vigente = Convert.ToBoolean(dr["vigente"]),
                    });
                }

                con.Close();

                return tipoDocumentos;
            }
            catch (Exception ex)
            {
                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "GetTiposDocumentos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();

                return tipoDocumentos;
            }
        }
    }
}
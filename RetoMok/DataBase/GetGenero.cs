using RetoMok.ConexionDataBase;
using RetoMok.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetoMok.DataBase
{
    public class GetGenero
    {
        List<Genero> generos = new List<Genero>();

        private SqlConnection con;

        private const string sql = @"SELECT [idGenero] , [descripcion], [vigente]
                     FROM [RetoMok].[PAR].[Genero]";

        public GetGenero()
        {
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();
        }

        public List<Genero> Get()
        {
            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    generos.Add(new Genero
                    {
                        idGenero = Convert.ToInt32(dr["idGenero"]),
                        descripcion = Convert.ToString(dr["descripcion"]),
                        vigente = Convert.ToBoolean(dr["vigente"]),
                    });
                }

                con.Close();
                return generos;
            }
            catch (Exception ex)
            {
                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "GetTiposDocumentos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();

                return generos;
            }
        }
    }
}
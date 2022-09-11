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
    public class GetCompraProducto
    {
        List<CompraByUsuario> compraByUsuario = new List<CompraByUsuario>();

        private int IdUsuario;

        private SqlConnection con;

        private const string sql = @" 
             SELECT VP.idVenta,VP.idProducto,U.Pnombre,U.Papellido ,P.Titulo FROM [RetoMok].[dbo].[VentaProducto] VP
             INNER JOIN [dbo].[Usuarios] U ON VP.IdUsuario = VP.IdUsuario
             INNER JOIN [dbo].[Producto] P ON P.idProducto = VP.idProducto
             WHERE U.IdUsuario = @IdUsuario";

        public GetCompraProducto(IdUsuario idUsuario)
        {
            IdUsuario = idUsuario.idUsuario;
        }

        public List<CompraByUsuario> Get()
        {
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();

            try
            {

                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    compraByUsuario.Add(new CompraByUsuario
                    {
                        idVenta = Convert.ToInt32(dr["idVenta"]),
                        idProducto = Convert.ToInt32(dr["idProducto"]),
                        Pnombre = Convert.ToString(dr["Pnombre"]),
                        Papellido = Convert.ToString(dr["Papellido"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                    });
                }

                con.Close();
                return compraByUsuario;

            }
            catch (Exception ex)
            {

                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "GetTiposDocumentos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();

                throw;
            }
        }
    }
}
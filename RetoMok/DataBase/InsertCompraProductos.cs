using RetoMok.ConexionDataBase;
using RetoMok.Models;
using RetoMok.Models.Constantes;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RetoMok.DataBase
{
    public class InsertCompraProductos
    {
        private SqlConnection con;

        CompraProductos compras = new CompraProductos();

        VentaProducto ventas = new VentaProducto();

        Respuesta respuesta = new Respuesta();

        private const string sql = @"
        INSERT INTO [dbo].[VentaProducto]([IdUsuario] ,[idProducto] ,[FechaVenta])
             VALUES (@IdUsuario, @idProducto , @FechaVenta)";

        public InsertCompraProductos(VentaProducto venta)
        {
            ventas = venta;
        }

        public Respuesta Insert()
        {

            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();

            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;

                con.Open();
                comando.Parameters.Add("@IdUsuario", SqlDbType.VarChar).Value = ventas.idProducto;
                comando.Parameters.Add("@idProducto", SqlDbType.VarChar).Value = ventas.IdUsuario;     
                comando.Parameters.Add("@FechaVenta", SqlDbType.DateTime).Value = DateTime.Now;
                comando.ExecuteNonQuery(); //execute the Query
                con.Close();

                respuesta.mensajeExtra = "";
                respuesta.mensaje = MensajesRespuesta.Exitoso;
                respuesta.codigo = 0;

                return respuesta;

            }
            catch (Exception ex)
            {

                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "InsertCompraProductos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();

                respuesta.mensajeExtra = ex.ToString();
                respuesta.mensaje = MensajesRespuesta.ErrorDataBase + logErrores.Pagina;
                respuesta.codigo = -1;

                return respuesta;
            }

        }

    }
}
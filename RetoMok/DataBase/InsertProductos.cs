using RetoMok.ConexionDataBase;
using RetoMok.Models;
using RetoMok.Models.Constantes;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RetoMok.DataBase
{
    public class InsertProductos
    {
       Productos producto = new Productos();

        private SqlConnection con;

        Respuesta respuesta = new Respuesta();

        private const string sql = @"
        INSERT INTO [dbo].[Producto]([Descripcion], [Titulo], [imagen], [FechaCreacion], [vigente], [Valor])
         VALUES (@Descripcion, @Titulo, @imagen, @FechaCreacion, @vigente , @Valor";

        public InsertProductos(Productos productos)
        {
            producto = productos;
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
                comando.Parameters.Add("@imagen", SqlDbType.VarChar).Value = producto.imagen;
                comando.Parameters.Add("@Titulo", SqlDbType.VarChar).Value = producto.Titulo;
                comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = producto.Descripcion;
                comando.Parameters.Add("@Valor", SqlDbType.Decimal).Value = producto.Valor;
                comando.Parameters.Add("@vigente", SqlDbType.Bit).Value = producto.vigente;
                comando.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = DateTime.Now;
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
                logErrores.Pagina = "GetTiposDocumentos";
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
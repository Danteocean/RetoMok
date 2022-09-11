using RetoMok.ConexionDataBase;
using RetoMok.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RetoMok.DataBase
{
    public class GetProductos
    {
        private SqlConnection con;

        List<Productos> productos = new List<Productos>();

        private const string sql = @"
                SELECT [idProducto],[Descripcion],[Titulo] ,[imagen],[FechaCreacion] ,[vigente] ,[Valor]
                FROM [RetoMok].[dbo].[Producto] 
                WHERE [vigente] = 1";

        public GetProductos()
        {
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();
        }

        public List<Productos> Get()
        {

            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    productos.Add(new Productos
                    {
                        idProducto = Convert.ToInt32(dr["idProducto"]),
                        Descripcion = Convert.ToString(dr["Descripcion"]),
                        Titulo = Convert.ToString(dr["Titulo"]),
                        imagen = Convert.ToString(dr["imagen"]),
                        FechaCreacion= Convert.ToDateTime(dr["FechaCreacion"]),
                        Valor = Convert.ToDecimal(dr["Valor"]),
                        vigente = Convert.ToBoolean(dr["vigente"]),
                    });
                }

                con.Close();
                return productos;
            }
            catch (Exception ex)
            {

                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "GetTiposDocumentos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();
                return productos;
            }

        }
    }
}
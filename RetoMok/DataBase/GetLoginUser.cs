using RetoMok.ConexionDataBase;
using RetoMok.DataBase;
using RetoMok.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RetoMok.Models
{
    public class GetLoginUser
    {
        LoginUsuario loginUsuario = new LoginUsuario();

        private SqlConnection con;

        private string pass = "";

        private const string sql = @"
                SELECT  [IdUsuario] ,[IdTipoDocumento] ,Documento ,[Pnombre] ,[Papellido] ,[Sapellido] ,[Contraseña] ,[idPerfil]
                FROM [RetoMok].[dbo].[Usuarios]
                 WHERE Documento = @DOCUMENTO ";

        public GetLoginUser(LoginUsuario login)
        {
            loginUsuario = login;
        }


        public Usuario Get()
        {
            Usuario usuario = new Usuario();
            ConexionData conexionBD = new ConexionData();
            con = conexionBD.Conectar();
            try
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                comando.Parameters.AddWithValue("@DOCUMENTO", loginUsuario.documento);

                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {

                    usuario.idUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.idTipoDocumento = Convert.ToInt32(dr["IdTipoDocumento"]);
                    usuario.documento = Convert.ToString(dr["Documento"]);
                    usuario.Pnombre = Convert.ToString(dr["Pnombre"]);
                    usuario.Papellido = Convert.ToString(dr["Sapellido"]);
                    pass = Convert.ToString(dr["Contraseña"]);
                    usuario.idPerfil= Convert.ToInt32(dr["idPerfil"]);
                }

                SecurityManager2 securityManager = new SecurityManager2();
                pass = securityManager.Decrypt(pass);

                if (pass != loginUsuario.contraseña || usuario == null)
                {
                    usuario.idUsuario = 0;
                    usuario.idTipoDocumento = 0;
                    usuario.Pnombre = "Acceso denegado";
                    usuario.Papellido = "";
                    return usuario;
                }
                usuario.token = TokenGenerator.GenerateTokenJwt(usuario.idUsuario.ToString());

                con.Close();

                return usuario;
            }
            catch (Exception ex)
            {

                LogErrores logErrores = new LogErrores();
                logErrores.Pagina = "GetTiposDocumentos";
                logErrores.Descripcion = ex.ToString();
                InsertLogErrores insertLogErrores = new InsertLogErrores(logErrores);
                insertLogErrores.InsertErrores();

                return usuario;
            }

        }
    }
}
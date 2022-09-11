using RetoMok.DataBase;
using RetoMok.Models;
using RetoMok.Models.Constantes;

namespace RetoMok.Bussines
{
    public class BussinesProducto
    {
        Productos productos = new Productos();

        Respuesta respuesta = new Respuesta();

        public BussinesProducto(Productos producto)
        {
            producto = productos;
        }

        public Respuesta Process()
        {
            if (valide())
            {
                InsertProductos insertProductos = new InsertProductos(productos);
                return insertProductos.Insert();
            }
            else
            {
                respuesta.mensajeExtra = "";
                respuesta.mensaje = MensajesRespuesta.Error;
                respuesta.codigo = -1;
                return respuesta;
            }
        }

        private bool valide()
        {
            if (string.IsNullOrEmpty(productos.Descripcion))
            {
                respuesta.mensajeExtra = MensajesRespuesta.Descripcion;
                return false;
            }
            if (string.IsNullOrEmpty(productos.imagen))
            {
                respuesta.mensajeExtra = MensajesRespuesta.imagen;
                return false;
            }
            if (string.IsNullOrEmpty(productos.Titulo))
            {
                respuesta.mensajeExtra = MensajesRespuesta.Titulo;
                return false;
            }
            return true;
        }
    }
}
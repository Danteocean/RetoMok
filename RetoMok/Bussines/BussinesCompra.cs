using RetoMok.DataBase;
using RetoMok.Models;
using RetoMok.Models.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetoMok.Bussines
{
    public class BussinesCompra
    {
  

        VentaProducto ventas = new VentaProducto();

        Respuesta respuesta = new Respuesta();

        public BussinesCompra(VentaProducto venta)
        {
            ventas = venta;
        }

        public Respuesta Process()
        {
            if (valide())
            {
                InsertCompraProductos insertCompraProductos = new InsertCompraProductos(ventas);
                return insertCompraProductos.Insert();
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
            if (ventas.idProducto == 0)
            {
                respuesta.mensajeExtra = MensajesRespuesta.Producto;
                return false;
            }
            if (ventas.IdUsuario == 0)
            {
                respuesta.mensajeExtra = MensajesRespuesta.Usuario;
                return false;
            }          
            return true;
        }

    }
}
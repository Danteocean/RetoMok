using System;

namespace RetoMok.Models
{
    public class CompraProductos : VentaProducto
    {
        public int idVenta { get; set; }

        public DateTime FechaVenta { get; set; }
    }
}
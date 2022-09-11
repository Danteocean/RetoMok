using System;

namespace RetoMok.Models
{
    public class Productos
    {
        public int idProducto { get; set; }

        public string Descripcion { get; set; }

        public string Titulo { get; set; }

        public string imagen { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool vigente { get; set; }

        public decimal Valor { get; set; }
    }
}
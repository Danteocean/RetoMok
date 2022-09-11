namespace RetoMok.Models
{
    public class CompraByUsuario
    {
        public int idUsuario { get; set; }

        public int idVenta { get; set; }

        public int idProducto { get; set; }

        public string Pnombre { get; set; }

        public string Papellido { get; set; }

        public string Titulo { get; set; }
    }
}
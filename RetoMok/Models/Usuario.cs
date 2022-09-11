namespace RetoMok.Models
{
    public class Usuario : LoginUsuario
    {
        public int idUsuario { get; set; }

        public int idTipoDocumento { get; set; }

        public string Pnombre { get; set; }

        public string Papellido { get; set; }       

        public string token { get; set; }

    }

    public class IdUsuario 
    {
        public int idUsuario { get; set; }
    }
}
using RetoMok.DataBase;
using System.Web.Http;

namespace RetoMok.Controllers
{
    [RoutePrefix("api/Service")]
    [Authorize]
    public class ServiciosController : ApiController
    {
        [HttpGet]
        [Route("TiposDocumentos")]
        public IHttpActionResult GetTiposDocumentos()
        {
            GetTiposDocumentos getTiposDocumentos = new GetTiposDocumentos();
            return Ok(getTiposDocumentos.Get());
        }

        [HttpGet]
        [Route("Genero")]
        public IHttpActionResult GetGenero()
        {
            GetGenero getGenero = new GetGenero();
            return Ok(getGenero.Get());
        }
    }
}
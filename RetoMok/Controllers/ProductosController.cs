using RetoMok.Bussines;
using RetoMok.DataBase;
using RetoMok.Models;
using System.Web.Http;

namespace RetoMok.Controllers
{
    [RoutePrefix("api/Producto")]
    [Authorize]
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("Productos")]
        public IHttpActionResult GetProductos()
        {
            GetProductos getProductos = new GetProductos();
            return Ok(getProductos.Get());
        }

        [HttpPost]
        [Route("Productos")]
        public IHttpActionResult PostProductos(Productos producto)
        {
            BussinesProducto bussinesProducto = new BussinesProducto(producto);
            return Ok(bussinesProducto.Process());
        }
    }
}

using RetoMok.Bussines;
using RetoMok.DataBase;
using RetoMok.Models;
using System.Web.Http;

namespace RetoMok.Controllers
{
    [RoutePrefix("api/Compra")]
    [Authorize]
    public class CompraController : ApiController
    {

        [HttpGet]
        [Route("Compra")]
        public IHttpActionResult GetProductos(IdUsuario idUsuario)
        {
            GetCompraProducto getCompraProducto = new GetCompraProducto(idUsuario);
            return Ok(getCompraProducto.Get());
        }

        [HttpPost]
        [Route("Venta")]
        public IHttpActionResult PostProductos(VentaProducto venta)
        {
            BussinesCompra bussinesCompra = new BussinesCompra(venta);
            return Ok(bussinesCompra.Process());
        }

    }
}

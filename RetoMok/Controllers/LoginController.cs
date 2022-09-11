using RetoMok.Models;
using RetoMok.Seguridad;
using System.Security;
using System.Web.Http;

namespace RetoMok.Controllers
{
    //12345678
    [RoutePrefix("api/Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {

        [HttpPost]
        [Route("ingreso")]
        public IHttpActionResult logueo(LoginUsuario LoginUsuario)
        {
            GetLoginUser getLoginUser = new GetLoginUser(LoginUsuario);
            return Ok(getLoginUser.Get());

        }
    }
}

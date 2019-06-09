using System;
using System.Web.Http;

namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Контроллер 
    /// </summary>
    public class AccountsController : ApiController
    {
        [Route("test")]
        public void Test()
        {
            throw new Exception("BOOM!");
        }
    }
}
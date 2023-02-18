using Microsoft.AspNetCore.Mvc;

namespace OneTimePassword.API.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public string Index()
        {
            return "Server is up and running";
        }
    }
}

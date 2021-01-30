using DataAnalyze.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DataAnalyze.Net.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TelecomContext _telecomContext;

        public UserController(TelecomContext telecomContext)
        {
            _telecomContext = telecomContext;
        }

        // GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
    }
}
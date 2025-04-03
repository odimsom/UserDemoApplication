using Microsoft.AspNetCore.Mvc;

namespace Application.Api.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

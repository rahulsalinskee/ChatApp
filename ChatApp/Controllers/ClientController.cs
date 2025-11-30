using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

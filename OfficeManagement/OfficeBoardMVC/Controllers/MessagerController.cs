using Microsoft.AspNetCore.Mvc;

namespace OfficeBoardMVC.Controllers
{
    public class MessagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

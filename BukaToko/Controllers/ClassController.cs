using Microsoft.AspNetCore.Mvc;

namespace BukaToko.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

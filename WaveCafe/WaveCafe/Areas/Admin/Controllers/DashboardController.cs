using Microsoft.AspNetCore.Mvc;

namespace WaveCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}

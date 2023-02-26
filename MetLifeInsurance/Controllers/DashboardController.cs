using Microsoft.AspNetCore.Mvc;

namespace MetLifeInsurance.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

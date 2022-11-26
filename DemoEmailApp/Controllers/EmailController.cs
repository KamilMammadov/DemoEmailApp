using Microsoft.AspNetCore.Mvc;

namespace DemoEmailApp.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}

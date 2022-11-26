using DemoEmailApp.AppDataBase;
using DemoEmailApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmailApp.Controllers
{
    public class EmailController : Controller
    {
        private readonly DataContext _dataContext;
    
        public EmailController(DataContext dataContext)
        {
            _dataContext = dataContext;
           
        }


        public IActionResult List()
        {
            var model = _dataContext.Notifications
                .Select(e=> new ListViewModel( e.From, $"{e.TargetEmail.TargetEmail}", e.Tittle, e.Message))
                .ToList();

            return View(model);
        }

    }
}

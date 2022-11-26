using DemoEmailApp.AppDataBase;
using DemoEmailApp.Database;
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



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddViewModel model)
        {
            

            var not = new Notifications.Model.Notification
            {
               From = model.From,
               TargetEmail = model.TargetEmail,
               Tittle=model.Tittle,
               Message=model.Message,
            };
         

            _dataContext.Notifications.Add(not);
            _dataContext.Emails.Add(not.TargetEmail);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(List));
        }


    }
}

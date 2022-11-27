using DemoEmailApp.AppDataBase;
using DemoEmailApp.Database;
using DemoEmailApp.EmailService;
using DemoEmailApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoEmailApp.Controllers
{
    public class EmailController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IEmailSender _emailSender;
    
        public EmailController(DataContext dataContext,IEmailSender emailsender)
        {
            _dataContext = dataContext;
            _emailSender = emailsender;
           
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
        public IActionResult Add([FromForm] AddViewModel model,FormCollection form)
        {
            

            var not = new Notifications.Model.Notification
            {
               From = model.From,
               TargetEmail = model.TargetEmail,
               Tittle=model.Tittle,
               Message=model.Message,
            };

            string radio = form["aa"].ToString();



            var newemails = not.TargetEmail.TargetEmail.Split(',');
            List<string> emails = new List<string>();
            foreach (var e in newemails)
            {
                emails.Add(e);
            }
            
            var message = new Message(emails, not.Tittle ,not.Message);

            _dataContext.Notifications.Add(not);
            _emailSender.SendEmail(message);
            _dataContext.Emails.Add(not.TargetEmail);
            _dataContext.SaveChanges();



            return RedirectToAction(nameof(List));
        }


    }
}

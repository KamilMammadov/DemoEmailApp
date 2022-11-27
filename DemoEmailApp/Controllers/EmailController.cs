using DemoEmailApp.AppDataBase;
using DemoEmailApp.Database;
using DemoEmailApp.EmailService;
using DemoEmailApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
        public IActionResult Add([FromForm] AddViewModel model)
        {
            

            var not = new Notifications.Model.Notification
            {
               From = model.From,
               TargetEmail = model.TargetEmail,
               Tittle=model.Tittle,
               Message=model.Message,
            };

            List<string> emails = new List<string>();

            if (model.Status==false)
            {
             var newemails = not.TargetEmail.TargetEmail.Split(',');

                foreach (var e in newemails)
                {
                    emails.Add(e);
                }
            }
            else
            {
                emails.Add(model.TargetEmail.TargetEmail);
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

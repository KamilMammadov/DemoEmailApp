using DemoEmailApp.Database;

namespace DemoEmailApp.ViewModels
{
    public class AddViewModel
    {
    
        public string Tittle { get; set; }
        public string Message { get; set; }
        public Email TargetEmail { get; set; }
        public bool Status { get; set; }


    }
}

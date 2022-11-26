using DemoEmailApp.Database;

namespace DemoEmailApp.ViewModels
{
    public class ListViewModel
    {
       
        public string From { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
        public Email ToEmail { get; set; }

      
        public ListViewModel(string from, string tittle, string message, Email toemail)
        {
            From = from;
            Tittle = tittle;
            Message = message;
             ToEmail = toemail;
        }

    }
}

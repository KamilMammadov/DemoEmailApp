using DemoEmailApp.Database;

namespace DemoEmailApp.ViewModels
{
    public class ListViewModel
    {
       
        public string From { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
        public string ToEmail { get; set; }

      
        public ListViewModel(string from, string toemail, string tittle, string message)
        {
            From = from;
            ToEmail = toemail;
            Tittle = tittle;
            Message = message;
        }

    }
}

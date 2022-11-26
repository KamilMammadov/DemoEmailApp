using DemoEmailApp.Database;


namespace DemoEmailApp.Notifications.Model
{
    public class Notification
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Tittle { get; set; }
        public string Message { get; set; }
        public int TargetEmailId { get; set; }
        public Email TargetEmail { get; set; }
    }
}

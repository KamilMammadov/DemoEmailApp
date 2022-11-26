using DemoEmailApp.Notifications.Model;

namespace DemoEmailApp.Database
{
    public class Email
    {
        public int Id { get; set; }
        public string TargetEmail { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}

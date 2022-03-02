using Services.Enums;

namespace Services.Models.eArchive.Notifications
{
    public class DynamicNotificationRuleReceiver
    {
        public NotificationType NotificationType { get; set; }
        public string ReceiverValue { get; set; }
    }
}
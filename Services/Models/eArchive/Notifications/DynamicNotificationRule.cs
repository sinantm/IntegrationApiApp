using System.Collections.Generic;

namespace Services.Models.eArchive.Notifications
{
    public class DynamicNotificationRule
    {
        public string ?Id { get; set; }
        public string RuleName { get; set; }
        public List<DynamicNotificationRuleDetail> Details { get; set; }
        public List<DynamicNotificationRuleReceiver> Receivers { get; set; }
    }
}
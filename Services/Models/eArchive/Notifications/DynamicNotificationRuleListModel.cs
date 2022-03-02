using System.Collections.Generic;

namespace Services.Models.eArchive.Notifications
{
    public class DynamicNotificationRuleListModel
    {
        public string Id { get; set; }
        public string RuleName { get; set; }
        public List<DynamicNotificationRuleReceiver> Receivers { get; set; }
    }
}
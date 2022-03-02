using System.Collections.Generic;

namespace Services.Models.eArchive.Notifications
{
    public class DynamicNotificationRuleListModelPaginationResult
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<DynamicNotificationRuleListModel> Data { get; set; }
    }
}
using System.Threading.Tasks;
using Services.Models;
using Services.Models.eArchive.Notifications;
using Services.Models.eArchive.Notifications.Parameters;

namespace Services.Interface.eArchive
{
    public interface INotifications
    {
        Task<DynamicNotificationRuleListModelPaginationResult> GetDynamicrules(GetDynamicrulesParameters getDynamicrulesParameters);
        
        Task<DynamicNotificationRule> PostDynamicrules(DynamicNotificationRule dynamicNotificationRule);
        
        Task<DynamicNotificationRule> GetDynamicrulesId(string uuid);
        
        Task<string> PutDynamicrulesId(DynamicNotificationRule dynamicNotificationRule,string uuid);
        
        Task<string> DeleteDynamicrulesId(string uuid);
    }
}
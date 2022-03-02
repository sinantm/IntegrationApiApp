using Services.Service;
using Services.Service.eArchive;

namespace Services
{
    public class ApiClient
    {
        private readonly string _apiUrl;
        private readonly string _accessToken;

        public ApiClient(string apiUrl, string accessToken)
        {
            _apiUrl = apiUrl;
            _accessToken = accessToken;
        }

        public ServiceUploads Uploads => new ServiceUploads(_apiUrl, _accessToken);
        public ServiceInvoices Invoices => new ServiceInvoices(_apiUrl, _accessToken);
        public ServiceNotifications Notifications => new ServiceNotifications(_apiUrl, _accessToken);
        public ServiceFileExportTitles FileExportTitles => new ServiceFileExportTitles(_apiUrl, _accessToken);
        
        public ServiceExInvoices ExInvoices => new ServiceExInvoices(_apiUrl, _accessToken);
    }
}
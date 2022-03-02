using Services.Interface.eArchive;

namespace Services.Service.eArchive
{
    public class ServiceExInvoices: ServiceBase, IExInvoices
    {
        public ServiceExInvoices(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }
    }
}
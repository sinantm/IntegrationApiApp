using System;

namespace Services.Service
{
    public abstract class ServiceBase
    {
        protected readonly string ApiUrl;
        protected readonly string AccessToken;

        public ServiceBase(string apiUrl, string accessToken)
        {
            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                throw new ArgumentNullException(nameof(apiUrl));
            }

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            ApiUrl = apiUrl;
            AccessToken = accessToken;
        }
    }
}
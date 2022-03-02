using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Services.Interface.eArchive;
using Services.Models.eArchive;
using Services.Models.eArchive.Notifications;
using Services.Models.eArchive.Notifications.Parameters;
using Services.Models.eArchive.RequestPrameters;

namespace Services.Service.eArchive
{
    public class ServiceNotifications: ServiceBase , INotifications
    {
        public ServiceNotifications(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }
        
        #region GetDynamicrules
        public async Task<DynamicNotificationRuleListModelPaginationResult> GetDynamicrules(GetDynamicrulesParameters getDynamicrulesParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"sort",$"{getDynamicrulesParameters.Sort}" },
                    {"pageSize", $"{getDynamicrulesParameters.PageSize}" },
                    {"page", $"{getDynamicrulesParameters.Page}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/notifications/dynamicrules", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new DynamicNotificationRuleListModelPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<DynamicNotificationRuleListModelPaginationResult>(content, new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Converters ={
                            new JsonStringEnumConverter()
                        }
                    });
                }
                else
                {
                    Console.WriteLine(httpResponseMessage.StatusCode.GetHashCode().ToString());
                }
                
                return model;
            }
        }
        #endregion
        
        #region PostDynamicrules
        
        public async Task<DynamicNotificationRule> PostDynamicrules(DynamicNotificationRule dynamicNotificationRule)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/notifications/dynamicrules");
                
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(dynamicNotificationRule);

                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<DynamicNotificationRule>(content, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters ={
                        new JsonStringEnumConverter()
                    }
                });
                return model;
            }
        }
        #endregion
        
        #region GetDynamicrulesId
        public async Task<DynamicNotificationRule> GetDynamicrulesId(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/notifications/dynamicrules/{uuid}");

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<DynamicNotificationRule>(content, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters ={
                        new JsonStringEnumConverter()
                    }
                });
                return model;
            }
        }
        #endregion
        
        #region PutDynamicrulesId
        public async Task<string> PutDynamicrulesId(DynamicNotificationRule dynamicNotificationRule,string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{ApiUrl}/v1/notifications/dynamicrules/{uuid}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(dynamicNotificationRule);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Kural başarı ile Güncellendi. Durum Kodu:";
                }
                else
                {
                    response = "Hata. Durum Kodu:";
                    throw new System.Exception(response + httpResponseMessage.StatusCode.GetHashCode().ToString());
                }

                return response + httpResponseMessage.StatusCode.GetHashCode().ToString();
            }
        }
        #endregion
        
        #region DeleteDynamicrulesId
        public async Task<string> DeleteDynamicrulesId(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{ApiUrl}/v1/notifications/dynamicrules/{uuid}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Not Başarı ile Silindi. Durum Kodu:";
                }
                else
                {
                    response = "Hata. Durum Kodu:";
                    throw new System.Exception(response + httpResponseMessage.StatusCode.GetHashCode().ToString());
                }

                return response + httpResponseMessage.StatusCode.GetHashCode().ToString();
            }
        }
        #endregion
    }
}
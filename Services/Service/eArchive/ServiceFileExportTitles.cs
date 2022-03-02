using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Services.Enums;
using Services.Interface.eArchive;
using Services.Models.eArchive.Notifications;

namespace Services.Service.eArchive
{
    public class ServiceFileExportTitles: ServiceBase ,IFileExportTitles
    {
        public ServiceFileExportTitles(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }


        #region GetFileExportTitlesTitlesKeys
        public async Task<List<string>> GetFileExportTitlesTitlesKeys(FileExportTitlesDocumnetType documentType)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/definitions/fileexporttitles/{documentType.ToString()}/titlekeys");

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<List<string>>(content, new JsonSerializerOptions()
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
    }
}
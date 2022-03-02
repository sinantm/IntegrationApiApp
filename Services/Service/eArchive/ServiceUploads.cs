using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Rest;
using Services.Interface;
using Services.Models;
using Services.Models.eArchive;
using Services.Models.eArchive.Invoices.RequestPrameters;

namespace Services.Service
{
    public class ServiceUploads : ServiceBase, IUploadsService
    {
        public ServiceUploads(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }

        #region PostUploadsDocumentPreview
        public async Task<UploadDocumentPreviewResponse> UploadsDocumentPreview(DocumnetPreviewRequest file)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/uploads/document/preview");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(file.File);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                form.Add(fileContent, "file", $"{Guid.NewGuid()}.xml");
                
                httpRequest.Content = form;

                var httpResponse = await httpClient.SendAsync(httpRequest);

                var content = await httpResponse.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<UploadDocumentPreviewResponse>(content);

                return model;
            }
        }
        #endregion
        
        #region PostUploadsDocument
        public async Task<UploadDocumentResponse> UploadsDocument(UploadsDocumentRequest uploadsDocumentRequest)
        {
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/uploads/document");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(uploadsDocumentRequest.File);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                form.Add(fileContent, "file", $"{Guid.NewGuid()}.xml");
                form.Add(new StringContent($"{uploadsDocumentRequest.IsDirectSend}"), "IsDirectSend");
                form.Add(new StringContent(uploadsDocumentRequest.PreviewType), "PreviewType");
                form.Add(new StringContent(uploadsDocumentRequest.SourceApp), "SourceApp");
                form.Add(new StringContent(uploadsDocumentRequest.SourceAppRecordId), "SourceAppRecordId");
                
                httpRequest.Content = form;

                var httpResponse = await client.SendAsync(httpRequest);

                var content = await httpResponse.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<UploadDocumentResponse>(content);

                return model;
            }
        }
        #endregion
        
        #region PutUploadsDocument
        public async Task<UploadDocumentResponse> PutUploadsDocument(UploadsDocumentRequest uploadsDocumentRequest,string uuid)
        {
            using (var client = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"{ApiUrl}/v1/uploads/document/{uuid}");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var form = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(uploadsDocumentRequest.File);

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                form.Add(fileContent, "file", $"{Guid.NewGuid()}.xml");
                form.Add(new StringContent($"{uploadsDocumentRequest.IsDirectSend}"), "IsDirectSend");
                form.Add(new StringContent(uploadsDocumentRequest.PreviewType), "PreviewType");
                form.Add(new StringContent(uploadsDocumentRequest.SourceApp), "SourceApp");
                form.Add(new StringContent(uploadsDocumentRequest.SourceAppRecordId), "SourceAppRecordId");
                
                httpRequest.Content = form;

                var httpResponse = await client.SendAsync(httpRequest);

                var content = await httpResponse.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<UploadDocumentResponse>(content);

                return model;
            }
        }
        #endregion
    }
}
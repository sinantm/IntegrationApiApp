using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Rest;
using Services.Enums;
using Services.Interface.eArchive;
using Services.Models.eArchive;
using Services.Models.eArchive.Invoices.RequestPrameters;
using Services.Models.eArchive.RequestPrameters;

namespace Services.Service.eArchive
{
    public class ServiceInvoices: ServiceBase, IInvoiceService
    {
        public ServiceInvoices(string apiUrl, string accessToken) : base(apiUrl, accessToken)
        {
        }
        
        #region GetXml
        public async Task<FileResponseData<byte[]>> InvoicesXml(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/xml");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                var model = new FileResponseData<byte[]>()
                {
                    Result = content
                };

                return model;
            }
        }
        #endregion
        
        #region GetPdf

        public async Task<FileResponseData<byte[]>> InvoicesPdf(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/pdf");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                var model = new FileResponseData<byte[]>()
                {
                    Result = content
                };

                return model;
            }
        }
        #endregion
        
        #region PostInvoicesExport

        public async Task<FileResponseData<byte[]>> InvoicesExport(InvoicesExportRequest invoicesExportRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/export/{invoicesExportRequest.FileType}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(invoicesExportRequest.Uuids);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                
                var model = new FileResponseData<byte[]>()
                {
                    Result = content
                };

                return model;
            }
        }
        #endregion
        
        #region PostInvoicesCancel

        public async Task<string> InvoicesCancel(DocumentCancellationRequest documentCancellationRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/cancel");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(documentCancellationRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Seçilen Faturalar İptal Edildi. Durum Kodu:";
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
        
        #region PostInvoicesCanceledWithdraw

        public async Task<string> InvoicesCanceledWithdraw(DocumentCancellationRequest documentCancellationRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/canceled/withdraw");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(documentCancellationRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Seçilen Faturaların İptali geri alındı. Durum Kodu:";
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
        
        #region PutInvoicesTags

        public async Task<string> InvoicesTags(TagingRequest tagingRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{ApiUrl}/v1/invoices/tags");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(tagingRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Seçilen Faturalara Etiketler Başarı ile Eklendi. Durum Kodu:";
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
        
        #region PostInvoicesSaveCompanyInDocumnet
        
        public async Task<Company> InvoicesSaveCompanyInDocument(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/{uuid}/savecompanyindocument");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
        
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<Company>(content, new JsonSerializerOptions()
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
        
        #region PutInvoicesBulk
        public async Task<string> InvoicesBulk(BulkOperationRequest bulkOperationRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{ApiUrl}/v1/invoices/bulk/{bulkOperationRequest.Operation}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(bulkOperationRequest.Uuids);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Seçilen Faturalara durum ataması yapıldı. Durum Kodu:";
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
        
        #region GetInvoiceList
        public async Task<InvoicePaginationResult> Invoices(InvoicesPrameters invoicesPrameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"sort",$"{invoicesPrameters.Sort}" },
                    {"pageSize", $"{invoicesPrameters.PageSize}" },
                    {"page", $"{invoicesPrameters.Page}" },
                    {"startDate", $"{invoicesPrameters.StartDate}" },
                    {"endDate", $"{invoicesPrameters.EndDate}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new InvoicePaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<InvoicePaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoiceLast
        public async Task<List<Invoice>> InvoicesLast(LastInvoiceParameters lastInvoiceParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"invoiceStatus",$"{lastInvoiceParameters.InvoiceStatus}" },
                    {"reportDivisionStatus", $"{lastInvoiceParameters.ReportDivisionStatus}" },
                    {"includeCanceledDocuments", $"{lastInvoiceParameters.IncludeCanceledDocuments}" },
                    {"invoiceTypeCode", $"{lastInvoiceParameters.InvoiceTypeCode}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/last", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new List<Invoice>();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<List<Invoice>>(content, new JsonSerializerOptions()
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
        
        #region GetInvoiceDrafts
        public async Task<InvoicePaginationResult> InvoicesDrafts(DraftInvoicesParameters draftInvoicesParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"company",$"{draftInvoicesParameters.Company}" },
                    {"uuid", $"{draftInvoicesParameters.Uuid}" },
                    {"documentNumber", $"{draftInvoicesParameters.DocumentNumber}" },
                    {"sort", $"{draftInvoicesParameters.Sort}" },
                    {"pageSize", $"{draftInvoicesParameters.PageSize}" },
                    {"page", $"{draftInvoicesParameters.Page}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/drafts", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new InvoicePaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<InvoicePaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesDetail
        public async Task<InvoiceDetail> InvoicesDetail(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}");

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<InvoiceDetail>(content, new JsonSerializerOptions()
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

        #region GetDespatches
        public async Task<DespatchDocumentReferencePaginationResult> DespatchesInfo(CommonRequest despatchesRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"uuid",$"{despatchesRequest.Uuid}" },
                    {"sort",$"{despatchesRequest.Sort}" },
                    {"pageSize", $"{despatchesRequest.PageSize}" },
                    {"page", $"{despatchesRequest.Page}" }

                };

                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{despatchesRequest.Uuid}/despatches", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new DespatchDocumentReferencePaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<DespatchDocumentReferencePaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesTaxes
        public async Task<TaxInfoPaginationResult> InvoicesTaxes(CommonRequest commonRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"uuid",$"{commonRequest.Uuid}" },
                    {"sort",$"{commonRequest.Sort}" },
                    {"pageSize", $"{commonRequest.PageSize}" },
                    {"page", $"{commonRequest.Page}" }

                };

                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{commonRequest.Uuid}/taxes", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new TaxInfoPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<TaxInfoPaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesHistories
        public async Task<HistoryPaginationResult> InvoicesHistories(CommonRequest commonRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"uuid",$"{commonRequest.Uuid}" },
                    {"sort",$"{commonRequest.Sort}" },
                    {"pageSize", $"{commonRequest.PageSize}" },
                    {"page", $"{commonRequest.Page}" }

                };

                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{commonRequest.Uuid}/histories", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new HistoryPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<HistoryPaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesMailHistories
        public async Task<MailHistoryPaginationResult> InvoicesMailHistories(CommonRequest commonRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"uuid",$"{commonRequest.Uuid}" },
                    {"sort",$"{commonRequest.Sort}" },
                    {"pageSize", $"{commonRequest.PageSize}" },
                    {"page", $"{commonRequest.Page}" }

                };

                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{commonRequest.Uuid}/mailhistories", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new MailHistoryPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<MailHistoryPaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesMailAddresses
        public async Task<List<string>> InvoicesMailAddresses(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/mailaddresses");
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
        
        #region GetInvoicesSmsHistories
        public async Task<SmsHistoryPaginationResult> InvoicesSmsHistories(CommonRequest commonRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"uuid",$"{commonRequest.Uuid}" },
                    {"sort",$"{commonRequest.Sort}" },
                    {"pageSize", $"{commonRequest.PageSize}" },
                    {"page", $"{commonRequest.Page}" }

                };

                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{commonRequest.Uuid}/smshistories", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new SmsHistoryPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<SmsHistoryPaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesInternetInfos
        public async Task<InternetInfo> InvoicesInternetInfos(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/internetinfos");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);


                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                var model = System.Text.Json.JsonSerializer.Deserialize<InternetInfo>(content, new JsonSerializerOptions()
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
        
        #region GetInvoiceCanceledList
        public async Task<InvoiceCanceledPaginationResult> InvoicesCanceled(CanceledInvoicesParameters canceledInvoicesParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"sort",$"{canceledInvoicesParameters.Sort}" },
                    {"pageSize", $"{canceledInvoicesParameters.PageSize}" },
                    {"page", $"{canceledInvoicesParameters.Page}" },
                    {"startDate", $"{canceledInvoicesParameters.StartDate}" },
                    {"endDate", $"{canceledInvoicesParameters.EndDate}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/canceled", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new InvoiceCanceledPaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<InvoiceCanceledPaginationResult>(content, new JsonSerializerOptions()
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
        
        #region GetInvoiceCanceledLast
        public async Task<List<InvoiceCanceled>> InvoiceCanceledLast(LastInvoiceCanceledParameters lastInvoiceCanceledParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"reportDivisionStatus", $"{lastInvoiceCanceledParameters.ReportDivisionStatus}" }
                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/canceled/last", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new List<InvoiceCanceled>();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<List<InvoiceCanceled>>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesAttachments
        public async Task<List<Attachment>> InvoicesAttachments(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/attachments");

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<List<Attachment>>(content, new JsonSerializerOptions()
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
        
        #region GetInvoicesAttachmentsDownload
        public async Task<FileResponseData<byte[]>> InvoicesAttachmentsDownload(AttachmentsParameters attachmentsParameters)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{attachmentsParameters.Uuid}/attachments/{attachmentsParameters.Index}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsByteArrayAsync();
                
                var model = new FileResponseData<byte[]>()
                {
                    Result = content
                };
                
                return model;
            }
        }
        #endregion
        
        #region GetHtml

        public async Task<FileResponseData<string>> InvoicesHtml(string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/v1/invoices/{uuid}/html");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = new FileResponseData<string>()
                {
                    Result = content
                };
                return model;
            }
        }
        #endregion
        
        #region PostInvoicesEmailSend

        public async Task<string> InvoicesEmailSend(EmailSendRequest emailSendRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/email/send");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(emailSendRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                
                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Faturalar girilen adreslere mail gönderildi. Durum Kodu:";
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
        
        #region GetUserNotes
        public async Task<NotePaginationResult> UserNotes(CommonRequest userNotesRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var queryParams = new Dictionary<string, string>()
                {
                    {"sort",$"{userNotesRequest.Sort}" },
                    {"pageSize", $"{userNotesRequest.PageSize}" },
                    {"page", $"{userNotesRequest.Page}" }

                };
                
                string urlQueryParameters = QueryHelpers.AddQueryString($"{ApiUrl}/v1/invoices/{userNotesRequest.Uuid}/usernotes", queryParams); 
                
                var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlQueryParameters);
                
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequest);

                var model = new NotePaginationResult();
                
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    
                    model = System.Text.Json.JsonSerializer.Deserialize<NotePaginationResult>(content, new JsonSerializerOptions()
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
        
        #region PostUserNotes
        
        public async Task<Note> PostUserNotes(NoteRequest noteRequest,string uuid)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/v1/invoices/{uuid}/usernotes");
                
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(noteRequest);

                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");

                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var model = System.Text.Json.JsonSerializer.Deserialize<Note>(content, new JsonSerializerOptions()
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

        #region PutUserNotes
        public async Task<string> PutUserNotes(NotePutParameters notePutParameters,NoteRequest noteRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, $"{ApiUrl}/v1/invoices/{notePutParameters.Uuid}/usernotes/{notePutParameters.Id}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(noteRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                string response;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    response = "Not Başarı ile Güncellendi. Durum Kodu:";
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
        
        #region DeleteUserNotes
        public async Task<string> DeleteUserNotes(NotePutParameters noteDeleteParameters,NoteRequest noteRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{ApiUrl}/v1/invoices/{noteDeleteParameters.Uuid}/usernotes/{noteDeleteParameters.Id}");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                
                var contentJsonString = System.Text.Json.JsonSerializer.Serialize(noteRequest);
                
                httpRequestMessage.Content = new StringContent(contentJsonString,System.Text.Encoding.UTF8,"application/json");
                
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
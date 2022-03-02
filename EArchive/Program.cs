using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Services;
using Services.Enums;
using Services.Enums.Parameters;
using Services.Models;
using Services.Models.eArchive;
using Services.Models.eArchive.Invoices.RequestPrameters;
using Services.Models.eArchive.Notifications;
using Services.Models.eArchive.Notifications.Parameters;
using Services.Models.eArchive.RequestPrameters;

namespace EArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            //TOKEN KALDIRILDI
            var apiClient = new ApiClient("https://apitest.nes.com.tr/earchive", "");

            var content = new CommonRequest()
            {
                Page = 1,
                PageSize = 10,
                Sort = "CreatedAt desc",
                Uuid = "99863d08-a4ca-49ba-82f5-f78c9d36a2ae"
            };

            #region NOTIFICATIONS

            #region GetDynamicrules
            /*
            //Kayıtlı bildirim kurallarınıza bu uç ile ulaşabilirsiniz.
            var parameterDynamicrules = new GetDynamicrulesParameters()
            {
                Sort = "CreatedAt desc",
                Page = 1,
                PageSize = 10
            };
            //Kayıtlı bildirim kurallarınıza bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceDynamicrules = apiClient.Notifications.GetDynamicrules(parameterDynamicrules).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceDynamicrules.json"), System.Text.Json.JsonSerializer.Serialize<DynamicNotificationRuleListModelPaginationResult>(eArchiveInvoiceDynamicrules));
            */
            #endregion

            #region PostDynamicrules
            /*
            //Yeni bildirim kuralı oluşturmak için bu uç kullanılabilir.
            var contentDynamicNotificationRuleRequest = new DynamicNotificationRule()
            {
                RuleName = "Deneme5",
                Details = new List<DynamicNotificationRuleDetail>()
                {
                    new DynamicNotificationRuleDetail()
                    {
                        Value1 = "TICARIFATURA",
                        Value2 = "",
                        Operator = "Equal",
                        Property = "ProfileId"
                    }
                },
                Receivers = new List<DynamicNotificationRuleReceiver>()
                {
                    new DynamicNotificationRuleReceiver()
                    {
                        NotificationType = NotificationType.Mail,
                        ReceiverValue = "sinan.temel@nesbilgi.com.tr"
                    }
                }
            };
            var eArchiveNotificationsPostDynamicrules = apiClient.Notifications.PostDynamicrules(contentDynamicNotificationRuleRequest).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveNotificationsPostDynamicrules.json"), System.Text.Json.JsonSerializer.Serialize<DynamicNotificationRule>(eArchiveNotificationsPostDynamicrules));
            */
            #endregion

            #region GetDynamicrulesId
            /*
            //Kayıtlı bildirim kuralınızın detaylarına bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceDynamicrulesIdDetail = apiClient.Notifications.GetDynamicrulesId("6617e9af-c63c-4e28-b6d3-c2270f94cf70").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceDynamicrulesIdDetail.json"), System.Text.Json.JsonSerializer.Serialize<DynamicNotificationRule>(eArchiveInvoiceDynamicrulesIdDetail));
            */
            #endregion
            
            #region PutDynamicrulesId
            /*
            //Daha önce tanımlanmış kuralı güncellemek için bu uç kullanılabilir.
            var contentDynamicNotificationRuleRequest = new DynamicNotificationRule()
            {
                RuleName = "Deneme5Guncellendi",
                Details = new List<DynamicNotificationRuleDetail>()
                {
                    new DynamicNotificationRuleDetail()
                    {
                        Value1 = "TICARIFATURA",
                        Value2 = "",
                        Operator = "Equal",
                        Property = "ProfileId"
                    }
                },
                Receivers = new List<DynamicNotificationRuleReceiver>()
                {
                    new DynamicNotificationRuleReceiver()
                    {
                        NotificationType = NotificationType.Mail,
                        ReceiverValue = "eren.guney@nesbilgi.com.tr"
                    }
                }
            };

            var eArchiveInvoicePutDynamicrulesId = apiClient.Notifications.PutDynamicrulesId(contentDynamicNotificationRuleRequest,"6617e9af-c63c-4e28-b6d3-c2270f94cf70").Result;
            Console.WriteLine("Result: " + eArchiveInvoicePutDynamicrulesId);
            */
            #endregion
            
            #region DeleteDynamicrulesId
            /*
            //Kayıtlı bildirim kuralını silmek bu uç kullanılabilir.
            var eArchiveInvoiceDeleteDynamicrulesId = apiClient.Notifications.DeleteDynamicrulesId("ba86399b-6ad8-478a-8952-e7a5bb624395").Result;
            Console.WriteLine("Result: " + eArchiveInvoiceDeleteDynamicrulesId);
            */
            #endregion
            
            #endregion
            
            #region INVOICES

            #region InvoicesXml
            /*
            //UUID gönderip faturanın XML alma işlemi
            var eArchiveInvoiceXml = apiClient.Invoices.InvoicesXml("909af7fd-ec04-4698-9ef0-0d68510612ea").Result;
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceXml.xml"), eArchiveInvoiceXml.Result);
            */
            #endregion
            
            #region InvoicesPdf
            /*
            //UUID gönderip faturanın PDF alma işlemi
            var eArchiveInvoicePdf = apiClient.Invoices.InvoicesPdf("99863d08-a4ca-49ba-82f5-f78c9d35a2ae").Result;
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoicePdf.pdf"), eArchiveInvoicePdf.Result);
            */
            #endregion
            
            #region InvoicesExport
            /* Verilen Dosya Türne Göre Toplu fatura indirme
            //UUID gönderip faturanın XML alma işlemi
            var contentExport = new InvoicesExportRequest()
            {
                FileType = FileType.Xml,
                Uuids = new List<string>(){"99863d08-a4ca-49ba-82f5-f78c9d36a2ae","801d5933-4176-477a-94ce-3f2a681ca8aa","85a725e9-5e96-47a9-bb5e-c8b6996f34e8"}
            };

            var eArchiveExport = apiClient.Invoices.InvoicesExport(contentExport).Result;
            System.IO.File.WriteAllBytesAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"file.zip"), eArchiveExport.Result);
            */
            #endregion
            
            #region InvoicesCancel
            /*
            //UUID'si gönderilen faturaları iptal etme
            var contentCancellationRequest = new DocumentCancellationRequest()
            {
                Uuids = new List<string>(){"801d5933-4176-477a-94ce-3f2a681ca8aa","85a725e9-5e96-47a9-bb5e-c8b6996f34e8"}
            };

            var eArchiveInvoiceCanceled = apiClient.Invoices.InvoicesCancel(contentCancellationRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceCanceled);
            */
            #endregion
            
            #region InvoicesCanceledWithdraw
            /*
            //UUID'si gönderilen faturaların iptalini geri alır
            var contentCancellationRequest = new DocumentCancellationRequest()
            {
                Uuids = new List<string>(){"801d5933-4176-477a-94ce-3f2a681ca8aa"}
            };

            var eArchiveInvoiceCanceledWithdraw = apiClient.Invoices.InvoicesCanceledWithdraw(contentCancellationRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceCanceledWithdraw);
            */
            #endregion
            
            #region InvoicesTags
            /*
            //UUID'si gönderilen faturalara Gönderilen Etiket uuidleri ilgili faturalara ekler
            var contentTagingRequest = new TagingRequest()
            {
                Uuids = new List<string>(){"99863d08-a4ca-49ba-82f5-f78c9d36a2ae","99863d08-a4ca-49ba-82f5-f78c9d34a2ae"},
                Tags = new List<TagingKeyValuePair>() { 
                    new TagingKeyValuePair(){Key = "a4b2387c-dea0-4060-8e6f-84db195a2d74", Value = true},
                    new TagingKeyValuePair(){Key = "7387e735-0b38-4423-8f13-84b305f31a5e", Value = true},
                    new TagingKeyValuePair(){Key = "b58bdd0f-9fa7-4549-9c74-b886156ff069", Value = true}
                }
            };

            var eArchiveInvoiceCanceledWithdraw = apiClient.Invoices.InvoicesTags(contentTagingRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceCanceledWithdraw);
            */
            #endregion
            
            #region InvoicesSaveCompanyInDocument
            /*
            //E-Arşiv Fatura gelen giden müşteri kayıt etme
            var eArchiveInvoicesSaveCompanyInDocument = apiClient.Invoices.InvoicesSaveCompanyInDocument("99863d08-a4ca-49ba-82f5-f78c9d34a2ae").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoicesSaveCompanyInDocument.json"), System.Text.Json.JsonSerializer.Serialize<Company>(eArchiveInvoicesSaveCompanyInDocument));
            */
            #endregion
            
            #region InvoicesBulk
            /*
            //UUID'si gönderilen faturalara Durum ataması yapar
            var contentBulkOperationRequest = new BulkOperationRequest()
            {
                Uuids = new List<string>(){"99863d08-a4ca-49ba-82f5-f78c9d36a2ae","99863d08-a4ca-49ba-82f5-f78c9d34a2ae"},
                Operation = BulkOperation.Printed
            };

            var eArchiveInvoiceBulkOperation = apiClient.Invoices.InvoicesBulk(contentBulkOperationRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceBulkOperation);
            */
            #endregion
            
            #region Invoices
            /*
            var parameterInvoice = new InvoicesPrameters()
            {
                Sort = "CreatedAt desc",
                Page = 1,
                PageSize = 10,
                StartDate = "2022.01.01",
                EndDate = "2022.02.01"
            };
            //Düzenlenmiş olan e-Arşiv faturalarınıza bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceList = apiClient.Invoices.Invoices(parameterInvoice).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"InvoicesList.json"), System.Text.Json.JsonSerializer.Serialize<InvoicePaginationResult>(eArchiveInvoiceList));
            */
            #endregion
            
            #region InvoicesLast
            /*
            var parameterInvoice = new LastInvoiceParameters()
            {
                InvoiceStatus = ArchiveDocumentStatusParameter.All,
                ReportDivisionStatus = ReportDivisionStatusParameter.All,
                IncludeCanceledDocuments = false,
                InvoiceTypeCode = InvoiceTypeParameter.All
            };
            //Düzenlenmiş olan son 10 e-Arşiv faturanıza bu uç ile ulaşabilirsiniz.
            var eArchiveLastInvoiceList = apiClient.Invoices.InvoicesLast(parameterInvoice).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"LastInvoicesList.json"), System.Text.Json.JsonSerializer.Serialize<List<Invoice>>(eArchiveLastInvoiceList));
            */
            #endregion

            #region InvoicesDrafts
            /*
            var parameterDraftInvoice = new DraftInvoicesParameters()
            {
                Sort = "CreatedAt desc",
                Page = 1,
                PageSize = 10
            };
            //E-Arşiv Fatura taslaklarınıza bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceDraftsList = apiClient.Invoices.InvoicesDrafts(parameterDraftInvoice).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"DraftInvoicesList.json"), System.Text.Json.JsonSerializer.Serialize<InvoicePaginationResult>(eArchiveInvoiceDraftsList));
            */
            #endregion
            
            #region InvoicesDetail
            /*
            //E-Arşiv Fatura Detayı
            var eArchiveInvoiceDetail = apiClient.Invoices.InvoicesDetail("99863d08-a4ca-49ba-82f5-f78c9d34a2ae").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceDetail.json"), System.Text.Json.JsonSerializer.Serialize<InvoiceDetail>(eArchiveInvoiceDetail));
            */
            #endregion
            
            #region DespatchesInfo
            /*
            //Belge içerisinde belirtilen irsaliye bilgilerine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceDespatches = apiClient.Invoices.DespatchesInfo(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceDespatchInfo.json"), System.Text.Json.JsonSerializer.Serialize<DespatchDocumentReferencePaginationResult>(eArchiveInvoiceDespatches));
            */
            #endregion
            
            #region InvoicesTaxes
            /*
            //Belge içerisinde belirtilen vergi bilgilerine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceTaxes = apiClient.Invoices.InvoicesTaxes(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceTaxes.json"), System.Text.Json.JsonSerializer.Serialize<TaxInfoPaginationResult>(eArchiveInvoiceTaxes));
            */
            #endregion
            
            #region InvoicesHistories
            /*
            //Sorgulanan belgeye ait işlem geçmişine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceHistories = apiClient.Invoices.InvoicesHistories(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceHistories.json"), System.Text.Json.JsonSerializer.Serialize<HistoryPaginationResult>(eArchiveInvoiceHistories));
            */
            #endregion
            
            #region InvoicesMailHistories
            /*
            //Sorgulanan belgeye ait mail gönderim geçmişine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceMailHistories = apiClient.Invoices.InvoicesMailHistories(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceMailHistories.json"), System.Text.Json.JsonSerializer.Serialize<MailHistoryPaginationResult>(eArchiveInvoiceMailHistories));
            */
            #endregion

            #region InvoicesMailAddresses
            /*
            //Sorgulanan belge içerisindeki mail adreslerinin listesine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceMailAddresses = apiClient.Invoices.InvoicesMailAddresses("909af7fd-ec04-4698-9ef0-0d68510612ea");
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceMailAdresses.json"), System.Text.Json.JsonSerializer.Serialize<List<string>>(eArchiveInvoiceMailAddresses.Result));
            */
            #endregion
            
            #region InvoicesSmsHistories
            /*
            //Sorgulanan belgeye ait sms gönderim geçmişine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceSmsHistories = apiClient.Invoices.InvoicesSmsHistories(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceSmsHistories.json"), System.Text.Json.JsonSerializer.Serialize<SmsHistoryPaginationResult>(eArchiveInvoiceSmsHistories));
            */
            #endregion
            
            #region InvoicesInternetInfos
            /*
            //Sorgulanan belgeye ait internet satış bilgilerine bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceInternetInfos = apiClient.Invoices.InvoicesInternetInfos("909af7fd-ec04-4698-9ef0-0d68510612ea");
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceInternetInfos.json"), System.Text.Json.JsonSerializer.Serialize<InternetInfo>(eArchiveInvoiceInternetInfos.Result));
            */
            #endregion
            
            #region InvoicesCanceled
            /*
            var parameterInvoiceCanceled = new CanceledInvoicesParameters()
            {
                Sort = "CreatedAt desc",
                Page = 1,
                PageSize = 10,
                StartDate = "2022.01.01",
                EndDate = "2022.02.01"
            };
            //Düzenlenmiş olan e-Arşiv faturalarınıza bu uç ile ulaşabilirsiniz.
            var eArchiveInvoiceCanceledList = apiClient.Invoices.InvoicesCanceled(parameterInvoiceCanceled).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"InvoicesCanceledList.json"), System.Text.Json.JsonSerializer.Serialize<InvoiceCanceledPaginationResult>(eArchiveInvoiceCanceledList));
            */
            #endregion

            #region InvoiceCanceledLast
            /*
            var parameterLastInvoiceCanceled = new LastInvoiceCanceledParameters()
            {
                ReportDivisionStatus = ReportDivisionStatusParameter.All
            };
            //Düzenlenmiş olan son 10 e-Arşiv faturanıza bu uç ile ulaşabilirsiniz.
            var eArchiveLastInvoiceCanceledList = apiClient.Invoices.InvoiceCanceledLast(parameterLastInvoiceCanceled).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"LastInvoicesCanceledList.json"), System.Text.Json.JsonSerializer.Serialize<List<InvoiceCanceled>>(eArchiveLastInvoiceCanceledList));
            */
            #endregion
            
            #region InvoicesAttachmentsDownload
            /*
            var contentAttachmentRequest = new AttachmentsParameters()
            {
                Uuid = "769e2e84-57f7-4ccb-94a2-457075284f30",
                Index = 0
            };
            //Belgeye ait ek dokumanların indirilmesi için bu uç kullanılabilir.
            var eArchiveInvoiceAttachmentsIndex = apiClient.Invoices.InvoicesAttachmentsDownload(contentAttachmentRequest).Result;
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"InvoiceAttachment.jpg"), eArchiveInvoiceAttachmentsIndex.Result);
            */
            #endregion

            #region InvoicesAttachments
            /*
            //E-Arşiv Fatura Detayı
            var eArchiveInvoiceAttachments = apiClient.Invoices.InvoicesAttachments("769e2e84-57f7-4ccb-94a2-457075284f30").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceAttachments.json"), System.Text.Json.JsonSerializer.Serialize<List<Attachment>>(eArchiveInvoiceAttachments));
            */
            #endregion

            #region InvoicesHtml
            /*
            //UUID gönderip faturanın HTML alma işlemi
            var eArchiveInvoiceHtml = apiClient.Invoices.InvoicesHtml("99863d08-a4ca-49ba-82f5-f78c9d35a2ae").Result;
            System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceXml.html"), eArchiveInvoiceHtml.Result);
            */
            #endregion

            #region InvoicesEmailSend
            /*
            //UUID'si gönderilen faturalara Durum ataması yapar
            var contentEmailSendRequest = new EmailSendRequest()
            {
                Uuids = new List<string>(){"99863d08-a4ca-49ba-82f5-f78c9d36a2ae","99863d08-a4ca-49ba-82f5-f78c9d34a2ae"},
                EmailAdresses = new List<string>(){"sinan.temel@nesbilgi.com.tr","eren.guney@nesbilgi.com.tr"},
            };

            var eArchiveInvoiceEmailSendRequest = apiClient.Invoices.InvoicesEmailSend(contentEmailSendRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceEmailSendRequest);
            */
            #endregion
            
            #region UserNotes
            /*
            //E-Arşiv Fatura Notları Listeleme
            var eArchiveInvoiceUserNotes = apiClient.Invoices.UserNotes(content).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceUserNotes.json"), System.Text.Json.JsonSerializer.Serialize<NotePaginationResult>(eArchiveInvoiceUserNotes));
            //Console.WriteLine(eArchiveInvoiceUserNotes.Data.ToList().Count().ToString());
*/
            #endregion
            
            #region PostUserNotes
            /*
            var contentNoteRequest = new NoteRequest()
            {
                Content = "Deneme nottur. Nes",
            };
            //Belgeye kullanıcı notu eklemek için bu uç kullanılabilir.
            var eArchiveInvoicesPostUserNotes = apiClient.Invoices.PostUserNotes(contentNoteRequest,"99863d08-a4ca-49ba-82f5-f78c9d34a2ae").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoicesPostUserNotes.json"), System.Text.Json.JsonSerializer.Serialize<Note>(eArchiveInvoicesPostUserNotes));
            */
            #endregion

            #region PutUserNotes
            /*
            //Belgeye daha önce eklenmiş olan kullanıcı notunu güncellemek için bu uç kullanılabilir.
            var contentNoteParameters = new NotePutParameters()
            {
                Id = "f80d69b6-0d2e-4b4e-839a-deb14bd5b62f",
                Uuid = "99863d08-a4ca-49ba-82f5-f78c9d34a2ae"
            };

            var contentNoteRequest = new NoteRequest()
            {
                Content = "Not güncellind. Not eklendi"
            };

            var eArchiveInvoiceNotePut = apiClient.Invoices.PutUserNotes(contentNoteParameters,contentNoteRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceNotePut);
            */
            #endregion

            #region DeleteUserNotes
            /*
            //Kullanıcı tarafından oluşturulmuş olan notu silmek için bu uç kullanılabilir.
            var contentNoteParameters = new NotePutParameters()
            {
                Id = "04856af1-cdbc-4d5d-be9e-c6def3f94f76",
                Uuid = "99863d08-a4ca-49ba-82f5-f78c9d34a2ae"
            };

            var contentNoteRequest = new NoteRequest()
            {
                Content = "Not Silindi."
            };

            var eArchiveInvoiceNoteDelete = apiClient.Invoices.DeleteUserNotes(contentNoteParameters,contentNoteRequest).Result;
            Console.WriteLine("Result: " + eArchiveInvoiceNoteDelete);
            */
            #endregion

            #endregion

            #region FileExportTitles
            #region GetFileExportTitlesTitlesKeys
            /*
            //Dosya başlık tanımlamalarında kullanılabilecek kolonlara bu api ucu ile alınabilir
            var eArchiveInvoiceGetFileExportTitlesTitlesKeys = apiClient.FileExportTitles.GetFileExportTitlesTitlesKeys(FileExportTitlesDocumnetType.Invoice).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"eArchiveInvoiceGetFileExportTitlesTitlesKeys.json"), System.Text.Json.JsonSerializer.Serialize<List<string>>(eArchiveInvoiceGetFileExportTitlesTitlesKeys));
                        */
            #endregion
            #endregion

            #region UPLOADS

            #region UploadsDocument
            /*
            //Belge yüklemek için bu uç kullanılabilir

            var filePath = @"C:\Users\sinan\Desktop\hkskomisyoncu.xml";
            var contentUploadsDocumentRequest = new UploadsDocumentRequest()
            {
                File = System.IO.File.ReadAllBytes(filePath),
                IsDirectSend = true,
                PreviewType = "None",
                SourceApp = "Deneme",
                SourceAppRecordId = Guid.NewGuid().ToString()// test olduğu için new guid yapıldı.
            };

            var uploadsDocument = apiClient.Uploads.UploadsDocument(contentUploadsDocumentRequest);
            Console.WriteLine("Result: " + uploadsDocument.Result.documentNumber);
            */
            #endregion
            
            #region UploadsDocumentPreview
            /*
            //Belgeyi göndermeden önce görüntülemek için bu uç kullanılabilir
            var filePath = @"C:\Users\sinan\Desktop\earsivsatis.xml";
            var contentUploadsDocumentRequest = new DocumnetPreviewRequest()
            {
                File = System.IO.File.ReadAllBytes(filePath)
            };

            var uploadsDocumentPreview = apiClient.Uploads.UploadsDocumentPreview(contentUploadsDocumentRequest).GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"uploadsDocumentPreview.json"), System.Text.Json.JsonSerializer.Serialize<UploadDocumentPreviewResponse>(uploadsDocumentPreview));
            */
            #endregion
            
            #region PutUploadsDocument
            /*
            //Henüz onaylanmamış taslak belgeleri güncellemek için bu uç kullanılabilir
            var filePath = @"C:\Users\sinan\Desktop\earsivsatis.xml";
            var contentUploadsDocumentRequest = new UploadsDocumentRequest()
            {
                File = System.IO.File.ReadAllBytes(filePath),
                IsDirectSend = true,
                PreviewType = "None",
                SourceApp = "Deneme",
                SourceAppRecordId = Guid.NewGuid().ToString()// test olduğu için new guid yapıldı.
            };

            var uploadsDocumentPut = apiClient.Uploads.PutUploadsDocument(contentUploadsDocumentRequest,"769e2e84-57f7-4ccb-94a2-457075284f30").GetAwaiter().GetResult();
            System.IO.File.WriteAllTextAsync(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"uploadsDocumentPut.json"), System.Text.Json.JsonSerializer.Serialize<UploadDocumentResponse>(uploadsDocumentPut));
            */
            #endregion
            
            #endregion


            

            Console.ReadLine();
        }
    }
}
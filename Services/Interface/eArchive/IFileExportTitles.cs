using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Enums;

namespace Services.Interface.eArchive
{
    public interface IFileExportTitles
    {
        Task<List<string>> GetFileExportTitlesTitlesKeys(FileExportTitlesDocumnetType documnetType);
    }
}
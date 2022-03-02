using System.ComponentModel.DataAnnotations;

namespace Services.Enums.Parameters
{
    public enum ReportDivisionStatusParameter
    {
        /// <summary>
        ///     Hepsi
        /// </summary>
        [Display(Name = "all")]
        All = -1,

        /// <summary>
        ///     Rapor oluşturulmamış olanlar
        /// </summary>
        [Display(Name = "none")]
        None = 0,

        /// <summary>
        ///     İşlem bekleyenler 
        /// </summary>
        [Display(Name = "waiting")]
        Waiting = 1,

        /// <summary>
        ///     Başarılı olanlar 
        /// </summary>
        [Display(Name = "succeed")]
        Succeed = 2,

        /// <summary>
        ///     Hata alanlar 
        /// </summary>
        [Display(Name = "error")]
        Error = 4
    }
}
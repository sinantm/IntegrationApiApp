namespace Services.Enums
{
    public enum ArchiveDocumentStatus 
    {
        /// <summary>
        /// Kullanıcı tarafından gönderilmeyi bekliyor
        /// </summary>
        Waiting = 1,

        /// <summary>
        /// 
        /// </summary>
        WaitingSign = 2,

        /// <summary>
        /// 
        /// </summary>
        Signed = 4,

        /// <summary>
        /// 
        /// </summary>
        Error = 20
    }
}
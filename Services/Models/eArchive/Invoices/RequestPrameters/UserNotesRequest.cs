﻿namespace Services.Models.eArchive.RequestPrameters
{
    public class CommonRequest
    {
        public string Uuid { get; set; }
        public string Sort  { get; set; }
        public int PageSize  { get; set; }
        public int Page  { get; set; }
    }
}
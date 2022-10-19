using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Currency.Exchange.Core.DbEntities
{
    public class Log
    {
        [Key]
        public long LogId { get; set; }

        public string UserId { get; set; }
        public string IpAddress { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public bool? HasError { get; set; }
        public string ErrorMessage { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public long? Duration { get; set; }
        public DateTime? CreateOn { get; set; }
    }
}

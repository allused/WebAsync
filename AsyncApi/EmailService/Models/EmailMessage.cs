using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Models
{
    public struct EmailMessage
    {
        public string UserEmail { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
    }
}

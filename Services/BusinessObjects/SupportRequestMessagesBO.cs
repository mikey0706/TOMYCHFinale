using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessObjects
{
    public class SupportRequestMessagesBO
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public SupportRequestBO SupportRequest { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Report
    {
        public long Id { get; set; }
        public byte[] Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public ReportTypes ReportType { get; set; }
        public long FileSize { get; set; }
    }
}

using Common.Enums;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessObjects
{
    public class ReportBO
    {
        [Name("ReportId")]
        public long Id { get; set; }
        [Name("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [Name("PublicId")]
        public Guid PublicId { get; set; }
        [Name("ReportType")]
        public ReportTypes ReportType { get; set; }
        [Name("FileSize")]
        public long FileSize { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessObjects
{
    public class CsvMimeData
    {
        public byte[] Payload { get; set; }
        public string FileName { get; set; }
        public string MimeType = "text/csv";
    }
}

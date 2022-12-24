using Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class ReportNotFoundException : BaseDataException
    {
        public ReportNotFoundException(string message) : base(message)
        {
            ErrorCode = ErrorTypes.ReportNotFound;
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}

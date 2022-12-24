using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class BaseDataException : Exception
    {
        public ErrorTypes ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public BaseDataException(string message) : base(message) { }
    }
}

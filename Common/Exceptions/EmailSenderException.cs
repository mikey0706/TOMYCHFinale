using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class EmailSenderException : BaseDataException
    {
        public EmailSenderException(string message) : base(message)
        {
            ErrorCode = ErrorTypes.EmailSendFailed;
            StatusCode = HttpStatusCode.FailedDependency;
        }
    }
}

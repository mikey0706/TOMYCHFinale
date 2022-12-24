using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum ErrorTypes
    {
        Undefined = 1_001,

        ReportNotFound = 2_001,

        UserNotFound = 3_001,
        UserEmailExists = 3_002,
        UsersPasswordVerificationFailed = 3_003,

        SupportRequestNotFound = 4_001,

        EmailSendFailed = 5_001,

        TokenAuthenticationFailed = 6_001
    }
}

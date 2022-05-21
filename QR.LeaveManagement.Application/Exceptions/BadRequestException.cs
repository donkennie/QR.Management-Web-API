using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {

        public BadRequestException(string message): base(message)
        {

        }
    }
}

using QR.LeaveManagement.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveRequest
{
   public class ChangeLeaveRequestApprovalDTO: BaseDTO
    {

        public bool? Approval { get; set; }
    }
}

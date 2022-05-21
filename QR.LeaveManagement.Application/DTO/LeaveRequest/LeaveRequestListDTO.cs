using QR.LeaveManagement.Application.DTO.Common;
using QR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveRequest
{
    public class LeaveRequestListDTO: BaseDTO
    {
        public LeaveTypeDTO LeaveType { get; set; }

        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }
    }
}

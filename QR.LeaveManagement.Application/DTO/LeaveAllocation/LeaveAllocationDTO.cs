using QR.LeaveManagement.Application.DTO.Common;
using QR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveAllocation
{
    public class LeaveAllocationDTO: BaseDTO
    {

        public int NumberOfDays { get; set; }

        public LeaveTypeDTO LeaveType { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}

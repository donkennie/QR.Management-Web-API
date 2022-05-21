using QR.LeaveManagement.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveAllocation
{
    public class CreateLeaveAllocationDTO: ILeaveAllocationDTO
    {
        public int NumberOfDays { get; set; }

        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}

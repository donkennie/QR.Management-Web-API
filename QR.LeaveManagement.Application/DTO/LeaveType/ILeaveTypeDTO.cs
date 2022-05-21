    using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveType
{
    public interface ILeaveTypeDTO
    {
        public string Name { get; set; }

        public int DefaultDays { get; set; }
    }
}

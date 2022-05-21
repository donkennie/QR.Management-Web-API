using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand: IRequest<int>
    {
        public CreateLeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}

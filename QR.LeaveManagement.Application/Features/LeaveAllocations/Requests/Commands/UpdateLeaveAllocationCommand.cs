using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class UpdateLeaveAllocationCommand: IRequest<Unit>
    {

        public UpdateLeaveAllocationDTO LeaveAllocationDTO { get; set; }
    }
}

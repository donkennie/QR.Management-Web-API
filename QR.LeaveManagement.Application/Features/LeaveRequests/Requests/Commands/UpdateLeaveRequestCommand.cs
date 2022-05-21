using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand: IRequest<Unit>
    {

        public int Id { get; set; }

        public UpdateLeaveRequestDTO leaveRequestDTO { get; set; }

        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDTO { get; set; }
    }
}

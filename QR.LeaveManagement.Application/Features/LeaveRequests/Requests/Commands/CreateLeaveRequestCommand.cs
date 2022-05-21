using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveRequest;
using QR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDTO LeaveRequestsDTO { get; set; }
    }
}

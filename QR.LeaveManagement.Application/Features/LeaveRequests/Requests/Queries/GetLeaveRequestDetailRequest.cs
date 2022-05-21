using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest: IRequest<LeaveRequestDTO>
    {

        public int Id { get; set; }
    }
}

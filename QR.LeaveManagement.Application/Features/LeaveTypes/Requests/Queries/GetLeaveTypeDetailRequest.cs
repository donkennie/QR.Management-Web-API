using MediatR;
using QR.LeaveManagement.Application.DTO.Common;
using QR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest: IRequest<LeaveTypeDTO>
    {
        public int Id { get; set; }
    }
}

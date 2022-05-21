using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand: IRequest<int>
    {
        public CreateLeaveTypeDTO LeaveTypeDTO { get; set; }  // Problem might come here
    }
}

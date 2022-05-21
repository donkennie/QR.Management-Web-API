using FluentValidation;
using QR.LeaveManagement.Application.DTO.LeaveType.Validators;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveRequest.Validator
{
    public class CreateLeaveRequestDTOValidator: AbstractValidator<CreateLeaveRequestDTO>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDTOValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestDTOValidator(_leaveTypeRepository));
        }
    }
}

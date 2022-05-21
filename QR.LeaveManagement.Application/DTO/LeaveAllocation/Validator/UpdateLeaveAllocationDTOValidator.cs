using FluentValidation;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveAllocation.Validator
{
    public class UpdateLeaveAllocationDTOValidator:  AbstractValidator<UpdateLeaveAllocationDTO>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationDTOValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveAllocationDTOValidator(_leaveTypeRepository));

        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }

 
    }
}

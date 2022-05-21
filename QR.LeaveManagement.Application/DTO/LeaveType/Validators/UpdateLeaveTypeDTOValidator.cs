using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveType.Validators
{
    public class UpdateLeaveTypeDTOValidator: AbstractValidator<LeaveTypeDTO>
    {

        public UpdateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
                  
        }
    }
}

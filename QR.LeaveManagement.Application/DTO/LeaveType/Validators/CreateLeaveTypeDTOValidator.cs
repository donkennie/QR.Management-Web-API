using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveType.Validators
{
   public class CreateLeaveTypeDTOValidator: AbstractValidator<CreateLeaveTypeDTO>
    {

        public CreateLeaveTypeDTOValidator()
        {
            Include(new ILeaveTypeDTOValidator());
        }
    }
}

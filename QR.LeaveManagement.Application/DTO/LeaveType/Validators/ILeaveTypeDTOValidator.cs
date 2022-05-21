using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.DTO.LeaveType.Validators
{
    public class ILeaveTypeDTOValidator : AbstractValidator<ILeaveTypeDTO>
    {

        public ILeaveTypeDTOValidator()
        {

            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .NotNull()
                   .MaximumLength(50).WithMessage("{PropertyName} must not exceed {comparisonValue} characters");

            RuleFor(p => p.DefaultDays)
                   .NotEmpty().WithMessage("{PropertyName} is required")
                   .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
                   .LessThan(100).WithMessage("{PropertyName} must be less than {comparisonValue}");
        }
    }
    }

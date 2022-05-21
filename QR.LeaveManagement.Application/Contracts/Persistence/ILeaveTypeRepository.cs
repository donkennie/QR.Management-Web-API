using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
    {
    }
}

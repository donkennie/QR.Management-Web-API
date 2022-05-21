using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetleaveAllocationsWithDetails()
        {
            var leaveAllocation = await _dbContext.leaveAllocations
                .Include(p => p.LeaveType)
                .ToListAsync();

            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetleaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.leaveAllocations
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync();

            return leaveAllocation;
        }
    }
}

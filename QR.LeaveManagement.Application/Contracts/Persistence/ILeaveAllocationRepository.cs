using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
    {

        Task<LeaveAllocation> GetleaveAllocationWithDetails(int id);

        Task<List<LeaveAllocation>> GetleaveAllocationsWithDetails();


    }
}

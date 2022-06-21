using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveAllocation;

namespace QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDTO>
    {

        public int Id { get; set; }
    }
}

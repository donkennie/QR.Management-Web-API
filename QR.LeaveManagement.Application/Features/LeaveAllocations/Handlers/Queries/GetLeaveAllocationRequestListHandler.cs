using AutoMapper;
using MediatR;
using QR.LeaveManagement.Application.DTO.Common;
using QR.LeaveManagement.Application.DTO.LeaveAllocation;
using QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetAllocationRequestListHandler: IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
    {

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetAllocationRequestListHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveAllocationRepository.GetleaveAllocationsWithDetails();
            return _mapper.Map<List<LeaveAllocationDTO>>(leaveTypes);
        }

    }
}

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
    public class GetAllocationDetailRequestHandler: IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDTO>
    {

        private readonly ILeaveAllocationRepository _leaveAllocationtRepository;
        private readonly IMapper _mapper;

        public GetAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationtRepository, IMapper mapper)
        {
            _leaveAllocationtRepository = leaveAllocationtRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationtRepository.GetleaveAllocationWithDetails(request.Id);
           

            return _mapper.Map<LeaveAllocationDTO>(leaveAllocation);
        }

        
    }
}

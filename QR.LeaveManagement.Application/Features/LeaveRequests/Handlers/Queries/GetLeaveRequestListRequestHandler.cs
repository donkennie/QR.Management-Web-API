using AutoMapper;
using MediatR;
using QR.LeaveManagement.Application.DTO.Common;
using QR.LeaveManagement.Application.DTO.LeaveRequest;
using QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries
{
    public class GetLeaveRequestListRequestHandler: IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDTO>>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }


        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
        {
            var leaveRequests = await _leaveRequestRepository.GetleaveRequestsWithDetails();
            return _mapper.Map<List<LeaveRequestListDTO>>(leaveRequests);
        }
    }
}

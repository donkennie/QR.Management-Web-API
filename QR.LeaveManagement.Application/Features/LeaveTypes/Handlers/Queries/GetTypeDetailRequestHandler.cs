using AutoMapper;
using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveType;
using QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDTO>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}

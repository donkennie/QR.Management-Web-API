using AutoMapper;
using MediatR;
using QR.LeaveManagement.Application.DTO.LeaveRequest.Validator;
using QR.LeaveManagement.Application.Exceptions;
using QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using QR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler: IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateLeaveRequestDTOValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.leaveRequestDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.leaveRequestDTO != null)
            {

             _mapper.Map(request.leaveRequestDTO, leaveRequest);
             await _leaveRequestRepository.Update(leaveRequest);

            }
            else if(request.ChangeLeaveRequestApprovalDTO != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDTO.Approval);
            }

            return Unit.Value;
        }
    }
}

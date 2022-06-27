using AutoMapper;
using Moq;
using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Application.DTO.LeaveType;
using QR.LeaveManagement.Application.Exceptions;
using QR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using QR.LeaveManagement.Application.Profiles;
using QR.LeaveManagement.Application.Responses;
using QR.LeaveManagement.Application.UnitTest.Mocks;
using QR.LeaveManagement.Persistence.Repositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QR.LeaveManagement.Application.UnitTest.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
       
        private readonly CreateLeaveTypeDTO _leaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()      
        {
         _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            _leaveTypeDto = new CreateLeaveTypeDTO
            {
                DefaultDays = 15,
                Name = "Test DTO"
            };
        }


        [Fact]
        public async Task Valid_LeaveType_Added()
        {

            var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDTO = _leaveTypeDto }, CancellationToken.None);

            var leaveTypes = await _mockRepo.Object.GetAll();

            result.ShouldBeOfType<int>();

            leaveTypes.Count.ShouldBe(4);
        }

       

        [Fact]
        public async Task InValid_LeaveType_Added()
        {

            _leaveTypeDto.DefaultDays = -1;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
                (
                  async() => 
                     await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDTO = _leaveTypeDto} , CancellationToken.None)
                );

            var leaveTypes = await _mockRepo.Object.GetAll();

            leaveTypes.Count.ShouldBe(3);

            ex.ShouldNotBeNull();

        }
    }
}

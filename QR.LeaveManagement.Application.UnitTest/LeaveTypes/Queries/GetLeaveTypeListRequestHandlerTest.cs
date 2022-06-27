using AutoMapper;
using Moq;
using QR.LeaveManagement.Application.Contracts.Persistence;
using QR.LeaveManagement.Application.DTO.LeaveType;
using QR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using QR.LeaveManagement.Application.Profiles;
using QR.LeaveManagement.Application.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace QR.LeaveManagement.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}

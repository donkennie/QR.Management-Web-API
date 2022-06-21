using MediatR;
using Microsoft.AspNetCore.Mvc;
using QR.LeaveManagement.Application.DTO.LeaveRequest;
using QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using QR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using QR.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDTO>>> Get(bool isLoggedInUser = false)
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest()); //{ IsLoggedInUser = isLoggedInUser });
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveRequestDTO leaveRequest)
        {
            var command = new CreateLeaveRequestCommand { LeaveRequestsDTO = leaveRequest };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDTO leaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, leaveRequestDTO = leaveRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/changeapproval/5
        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDTO changeLeaveRequestApproval)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovalDTO = changeLeaveRequestApproval };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

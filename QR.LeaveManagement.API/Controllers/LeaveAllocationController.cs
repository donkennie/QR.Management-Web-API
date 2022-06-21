using MediatR;
using Microsoft.AspNetCore.Mvc;
using QR.LeaveManagement.Application.DTO.LeaveAllocation;
using QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using QR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
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
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get(bool isLoggedInUser = false)
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest()); //{ IsLoggedInUser = isLoggedInUser });
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }                                                                                                                                  

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveAllocationDTO leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDTO = leaveAllocation };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        // PUT api/<LeaveAllocationsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDTO leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { LeaveAllocationDTO = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}


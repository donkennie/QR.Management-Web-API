using MediatR;
using Microsoft.AspNetCore.Mvc;
using QR.LeaveManagement.Application.DTO.LeaveType;
using QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using QR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
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
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>>  Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLeaveTypeDTO leaveType)
        {
           // var user = _httpContextAccessor.HttpContext.User;
            var command = new CreateLeaveTypeCommand { LeaveTypeDTO = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] LeaveTypeDTO leaveType)
        {
            var command = new UpdateLeaveTypeCommand { leaveTypeDTO = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

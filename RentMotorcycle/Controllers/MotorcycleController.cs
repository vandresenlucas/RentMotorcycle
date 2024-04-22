using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Motorcycles.CommandHandler;
using RentMotorcycle.Application.Motorcycles.QueryHandlers;

namespace RentMotorcycle.Controllers
{
    [ApiController]
    [Route("RentMotorcycle/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MotorcycleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddMotorcycle")]
        public async Task<IActionResult> Post([FromBody] AddMotorcycleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult(false, ex.Message));
            }
        }

        [HttpGet(Name = "GetMotorcycle")]
        public async Task<IActionResult> Get([FromQuery] string? licensePlate)
        {
            try
            {
                var command = new MotorcycleGetByLicensePlate { licensePlate = licensePlate };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult(false, ex.Message));
            }
        }
    }
}

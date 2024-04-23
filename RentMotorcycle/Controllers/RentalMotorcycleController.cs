using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.RentalMotorcycles;

namespace RentMotorcycle.Controllers
{
    [ApiController]
    [Route("RentMotorcycle/[controller]")]
    public class RentalMotorcycleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalMotorcycleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddRentalMotorcycle")]
        public async Task<IActionResult> Post([FromBody] AddRentalMotorcycleCommand command)
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
    }
}

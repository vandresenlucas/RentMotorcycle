using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Motorcycles;

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

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Post([FromBody] AddMotorcycleCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

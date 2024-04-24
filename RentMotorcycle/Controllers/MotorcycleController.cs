using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.AddMotorcycle;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.DeleteMotorcycle;
using RentMotorcycle.Application.Motorcycles.CommandHandlers.UpdateLicensePlateMotorcycle;
using RentMotorcycle.Application.Motorcycles.MessageBroker;
using RentMotorcycle.Application.Motorcycles.QueryHandlers;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace RentMotorcycle.Controllers
{
    [ApiController]
    [Route("RentMotorcycle/[controller]")]
    public class MotorcycleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public MotorcycleController(IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost(Name = "AddMotorcycle")]
        public async Task<IActionResult> Post([FromBody] AddMotorcycleCommand command)
        {
            try
            {
                var message = new AddMotorcycleEvent
                {
                    IdentifyCode = command.IdentifyCode,
                    LicensePlate = command.LicensePlate,
                    Model = command.Model,
                    Year = command.Year
                };

                await _publishEndpoint.Publish(message, x => x.SetRoutingKey("fi-investment-mq"));

                //var result = await _mediator.Send(command);

                return Ok();
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
                var command = new GetMotorcycleByLicensePlate { licensePlate = licensePlate };
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult(false, ex.Message));
            }
        }

        [HttpPut(Name = "UpdateLicensePlateMotorcycle")]
        public async Task<IActionResult> Put([FromQuery] Guid motorcycleId, [FromBody] UpdateLicensePlateMotorcycleCommand command )
        {
            try
            {
                command.MotorcycleId = motorcycleId;
                var result = await _mediator.Send(command);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult(false, ex.Message));
            }
        }

        [HttpDelete(Name = "DeleteMotorcycle")]
        public async Task<IActionResult> Delete([FromQuery] Guid motorcycleId)
        {
            try
            {
                var command = new DeleteMotorcycleCommand { MotorcycleId = motorcycleId };
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

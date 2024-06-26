﻿using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Application.RentalMotorcycles.CommandHandlers.CalculateRentalMotorcyclePrice;
using RentMotorcycle.Application.RentalMotorcycles.MessageBroker;

namespace RentMotorcycle.Controllers
{
    [ApiController]
    [Route("RentMotorcycle/[controller]")]
    public class RentalMotorcycleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;

        public RentalMotorcycleController(IMediator mediator, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost(Name = "AddRentalMotorcycle")]
        public async Task<IActionResult> Post([FromBody] AddRentalMotorcycleEvent addEvent)
        {
            try
            {
                await _publishEndpoint.Publish(addEvent, x => x.SetRoutingKey("rk-add-rental-motorcycle"));

                return Ok("Aluguel da moto enviado para o sistema!!");
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResult(false, ex.Message));
            }
        }

        [HttpGet(Name = "CalculateRentalMotorcyclePrice")]
        public async Task<IActionResult> Get([FromQuery] Guid rentalMotorcycleId, [FromQuery] DateTime returnDate)
        {
            try
            {
                var command = new CalculateRentalMotorcyclePriceCommand { RentalMotorcycleId = rentalMotorcycleId, ReturnDate = returnDate };
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

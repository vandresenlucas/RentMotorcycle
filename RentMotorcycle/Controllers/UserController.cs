using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RentMotorcycle.Controllers
{
    [Route("RentMotorcycle/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

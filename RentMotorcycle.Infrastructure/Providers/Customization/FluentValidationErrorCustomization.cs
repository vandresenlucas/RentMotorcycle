using Microsoft.AspNetCore.Mvc;
using RentMotorcycle.Application.Base;

namespace RentMotorcycle.Infrastructure.Providers.Customization
{
    public static class FluentValidationErrorCustomization
    {
        public static void ErrorCustomization(this ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                var erro = context.ModelState.Values.FirstOrDefault().Errors.Select(e => e.ErrorMessage).FirstOrDefault();

                return new BadRequestObjectResult(new BaseResult(false, message: erro));
            };
        }
    }
}

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
                var errors = new Dictionary<string, string[]>();

                foreach (var (key, value) in context.ModelState)
                    errors.Add(key, value.Errors.Select(e => e.ErrorMessage).ToArray());

                return new BadRequestObjectResult(new BaseResult(false, errorMessages: errors));
            };
        }
    }
}

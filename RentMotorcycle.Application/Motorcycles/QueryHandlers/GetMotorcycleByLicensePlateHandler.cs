﻿using MediatR;
using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.QueryHandlers
{
    public class GetMotorcycleByLicensePlateHandler : IRequestHandler<GetMotorcycleByLicensePlate, BaseResult>
    {

        private readonly IMotorcycleRepository _motorcycleRepository;

        public GetMotorcycleByLicensePlateHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<BaseResult> Handle(GetMotorcycleByLicensePlate request, CancellationToken cancellationToken)
        {
            IList<Motorcycle>? motorcycles = new List<Motorcycle>();

            if (!string.IsNullOrEmpty(request.licensePlate))
            {
                var motorcycle = await _motorcycleRepository.GetByLicensePlate(request.licensePlate);

                if (motorcycle != null)
                    motorcycles.Add(motorcycle);

                return new BaseResult(result: motorcycles);
            }

            motorcycles = await _motorcycleRepository.GetMotorcycles();

            var teste = new BaseResult(result: motorcycles);
            return teste;
        }
    }
}

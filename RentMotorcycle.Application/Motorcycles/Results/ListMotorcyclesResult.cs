using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.Results
{
    public class ListMotorcyclesResult : BaseResult
    {
        public ListMotorcyclesResult(
            bool success = true, 
            string? message = null,
            List<Motorcycle>? motorcycles = null) : base(success, message)
        {
            Motorcycles = motorcycles;
        }

        public List<Motorcycle>? Motorcycles;
    }
}

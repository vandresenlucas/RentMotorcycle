using RentMotorcycle.Application.Base;
using RentMotorcycle.Data.MotorcycleAggregate;

namespace RentMotorcycle.Application.Motorcycles.Results
{
    public class ListMotorcyclesResult : BaseResult
    {
        public ListMotorcyclesResult(
            bool success = true, 
            string? message = null,
            IList<Motorcycle>? motorcycles = null) : base(success, message)
        {
            Motorcycles = motorcycles;
        }

        public IList<Motorcycle>? Motorcycles;
    }
}

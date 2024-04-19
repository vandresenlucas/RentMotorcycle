
namespace RentMotorcycle.Application.Base
{
    public class BaseEntityResult : BaseResult
    {
        public Guid? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public BaseEntityResult(bool success, string? message = null) : base(success, message)
        {
        }
    }
}

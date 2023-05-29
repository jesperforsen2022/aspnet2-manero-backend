using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface ICreditCardEntity
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        string CvvCode { get; set; }
        string ExpireMonth { get; set; }
        string ExpireYear { get; set; }
        Guid Id { get; set; }
        UserEntity User { get; set; }
        string UserId { get; set; }
    }
}
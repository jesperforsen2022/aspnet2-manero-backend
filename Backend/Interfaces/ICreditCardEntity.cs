using Backend.Models.Entities.User;

namespace Backend.Interfaces
{
    public interface ICreditCardEntity
    {
        string CardName { get; set; }
        string CardNumber { get; set; }
        int CvvCode { get; set; }
        int ExpireMonth { get; set; }
        int ExpireYear { get; set; }
        Guid Id { get; set; }
        UserEntity User { get; set; }
        string UserId { get; set; }
    }
}
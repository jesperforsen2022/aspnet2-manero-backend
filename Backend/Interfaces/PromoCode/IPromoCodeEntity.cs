namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeEntity
    {
        decimal Discount { get; set; }
        DateTime ExpiryDate { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
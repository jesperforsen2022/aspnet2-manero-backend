namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeSchema
    {
        decimal Discount { get; set; }
        DateTime ExpiryDate { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
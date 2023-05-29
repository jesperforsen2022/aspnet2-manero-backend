namespace Backend.Interfaces.PromoCode
{
    public interface IPromoCodeModel
    {
        decimal Discount { get; set; }
        DateTime ExpiryDate { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
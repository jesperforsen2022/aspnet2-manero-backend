using Backend.Interfaces;
using Backend.Models.Users.Dtos;

namespace Backend.Models.Entities
{
    public class OrderEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public OrderUserProfileModel Profile { get; set; } = null!;
        public List<OrderProductModel> Products { get; set; } = new List<OrderProductModel>();
        public string OrderStatus { get; set; } = "Order is placed";
        public string PaymentMethod { get; set; } = null!;
        public string? Comment { get; set; }
        public string Delivery { get; set; } = null!;
        public List<PromoCodeModel>? PromoCodes { get; set; } = new List<PromoCodeModel>();
        public static implicit operator OrderModel(OrderEntity entity)
        {
            return new OrderModel
            {
                Id = entity.Id,
                Price = entity.Price,
                Date = entity.Date,
                Profile = entity.Profile,
                Products = entity.Products,
                OrderStatus = entity.OrderStatus,
                PaymentMethod = entity.PaymentMethod,
                Comment = entity.Comment,
                Delivery = entity.Delivery,
                PromoCodes = entity.PromoCodes
            };
        }
    }
}

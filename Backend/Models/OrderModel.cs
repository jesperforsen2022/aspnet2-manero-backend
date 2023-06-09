﻿using Backend.Interfaces;
using Backend.Models.Dtos;
using Backend.Models.Entities;

namespace Backend.Models
{
    public class OrderModel : IOrderModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
        public OrderUserProfileModel? Profile { get; set; }
        public OrderAddressModel? Address { get; set; }
        public List<OrderProductModel>? Products { get; set; } = new List<OrderProductModel>();
        public string? OrderStatus { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public string? Comment { get; set; }
        public string Delivery { get; set; } = null!;
        public List<PromoCodeModel>? PromoCodes { get; set; } = new List<PromoCodeModel>();
    }
}

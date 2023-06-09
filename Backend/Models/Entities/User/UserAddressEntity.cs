﻿using Backend.Interfaces;

namespace Backend.Models.Entities.User
{
    public class UserAddressEntity : IUserAddressEntity
    {
        public string UserId { get; set; } = null!;
        public Guid AddressId { get; set; }
        public UserEntity User { get; set; } = null!;
        public AddressEntity Address { get; set; } = null!;
    }
}

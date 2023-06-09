﻿using Backend.Interfaces;
using Backend.Models.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Users.Schemas;

public class UserRegisterModel : IUserRegisterModel
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;

    public static implicit operator UserEntity(UserRegisterModel model)
    {
        return new UserEntity
        {
            Name = model.Name,
            Email = model.Email,
        };
    }
}

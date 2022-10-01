using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Users;
using CleanArch.Domain.Users.ValueObjects;
using CleanArch.Query.Products.DTOs;
using CleanArch.Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Users
{
    public class UserMapper
    {
        public static UserDto MapUserToDto(User? user)
        {
            if (user == null)
                return null;

            return new UserDto()
            {
                Name = user.Name,
                Family = user.Family,
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}

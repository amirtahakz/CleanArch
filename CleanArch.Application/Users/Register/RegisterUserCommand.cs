using CleanArch.Domain.Users.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Users.Register
{
    public class RegisterUserCommand : IRequest<Guid>
    {
        public RegisterUserCommand(string name, string family, string email, string phoneNumber)
        {
            Name = name;
            Family = family;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; set; }
        public string PhoneNumber { get; private set; }
    }
}

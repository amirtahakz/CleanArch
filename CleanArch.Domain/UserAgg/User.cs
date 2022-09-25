using CleanArch.Domain.Shared;
using CleanArch.Domain.UserAgg.Events;
using CleanArch.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Users
{
    public class User : AggregateRoot
    {
        private User()
        {

        }
        public User(string name, string family, PhoneNumber phoneNumber, string email)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public static User Register(string email)
        {
            var user = new User("", "", null, email);
            user.AddDomainEvent(new UserRegistered(user.Id , email));
            return user;
        }
    }
}

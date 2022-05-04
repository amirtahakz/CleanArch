using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.UserAgg.Events
{
    public class UserRegistered : BaseDomainEvent
    {
        public UserRegistered(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}

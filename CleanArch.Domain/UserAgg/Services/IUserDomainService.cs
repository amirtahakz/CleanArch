using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        public bool IsEmailExist(string email);
    }
}

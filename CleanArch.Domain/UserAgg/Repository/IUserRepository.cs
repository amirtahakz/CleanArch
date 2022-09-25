using CleanArch.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.UserAgg.Repository
{
    public interface IUserRepository
    {
        void Add(User user);

        Task<User> GetById(Guid id);

        Task<User> GetbyEmail(string email);

        bool UserIsExist(string email);

        Task SaveChange();

        void Update(User user);
    }
}

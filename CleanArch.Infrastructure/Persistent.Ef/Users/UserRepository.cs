using CleanArch.Domain.UserAgg.Repository;
using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.Ef.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public async Task<User> GetbyEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Email == email);
        }

        public async Task<User> GetById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public bool UserIsExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}

using CleanArch.Domain.ProductAgg.Events;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.UserAgg.Events;
using CleanArch.Domain.UserAgg.Repository;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Users;
using CleanArch.Query.Models.Users.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.EventHandlers.User
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegistered>
    {
        private readonly IUserReadRepository _readRepository;
        private readonly IUserRepository _writeRepository;

        public UserRegisteredEventHandler(IUserReadRepository readRepository, IUserRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
        {
            var user = await _writeRepository.GetById(notification.UserId);
            await _readRepository.Insert(new UserReadModel()
            {
                Id = user.Id,
                Email = user.Email,
                CreationDate = user.CreationDate,
                PhoneNumber = user.PhoneNumber,
                Name = user.Name,
                Family = user.Family
            });
        }
    }
}

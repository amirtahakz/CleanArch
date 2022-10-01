using CleanArch.Application.Products.Create;
using CleanArch.Domain.ProductAgg.Events;
using CleanArch.Domain.ProductAgg.Repository;
using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.UserAgg.Repository;
using CleanArch.Domain.Users;
using CleanArch.Domain.Users.ValueObjects;
using CleanArch.Domain.UserAgg.Services;
using CleanArch.Domain.UserAgg.Events;

namespace CleanArch.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        private readonly IUserDomainService _userDomainService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMediator mediator, IUserDomainService userDomainService)
        {
            _userRepository = userRepository;
            _mediator = mediator;
            _userDomainService = userDomainService;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            var user = User.Register(request.Email , request.PhoneNumber , _userDomainService);

            _userRepository.Add(user);

            await _userRepository.SaveChanges();

            await _mediator.Publish(new UserRegistered(user.Id , user.Email));
            //foreach (var @event in user.DomainEvents)
            //{
            //    await _mediator.Publish(@event);
            //}

            return user.Id;
        }
    }
}

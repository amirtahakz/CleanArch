using CleanArch.Query.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Users.GetByEmail
{
    public record GetByEmailQuery(string Email) : IRequest<UserReadModel>;
}

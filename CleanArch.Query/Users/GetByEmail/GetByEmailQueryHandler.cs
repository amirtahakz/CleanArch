using CleanArch.Query.Models.Products.Repository;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Query.Models.Users;
using CleanArch.Query.Models.Users.Repository;

namespace CleanArch.Query.Users.GetByEmail
{
    public class GetByEmailQueryHandler : IRequestHandler<GetByEmailQuery, UserReadModel>
    {
        private IUserReadRepository _readRepository;

        public GetByEmailQueryHandler(IUserReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<UserReadModel> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _readRepository.GetByEmail(request.Email);
        }
    }

}

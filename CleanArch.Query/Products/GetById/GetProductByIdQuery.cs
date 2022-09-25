using CleanArch.Query.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.GetById
{
    public record GetProductByIdQuery(Guid ProductId): IRequest<ProductDto>;
}

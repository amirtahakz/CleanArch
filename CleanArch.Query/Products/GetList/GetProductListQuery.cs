using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.GetList
{
    public record GetProductListQuery : IRequest<List<ProductReadModel>>;
}

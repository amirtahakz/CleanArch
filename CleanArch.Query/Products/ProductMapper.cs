﻿using CleanArch.Domain.ProductAgg;
using CleanArch.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products
{
    public class ProductMapper
    {
        public static ProductDto MapProductToDto(Product? product)
        {
            if (product == null)
                return null;

            return new ProductDto()
            {
                Description = product.Description,
                Images = product.Images.ToList(),
                Id = product.Id,
                Money = product.Money,
                Title = product.Title
            };
        }
    }
}

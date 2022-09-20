﻿using CleanArch.Domain.ProductAgg;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Money Money { get; private set; }
        public ICollection<ProductImage> Images { get; private set; }


        public Product(string title, Money money)
        {
            Guard(title);
            Title = title;
            Money = money;
            Id = Guid.NewGuid();
            Images = new List<ProductImage>();
        }
        public void AddImage(string imageName)
        {
            Images.Add(new ProductImage(Id , imageName));
        }
        public void RemoveImage(Guid id)
        {
            var image = Images.FirstOrDefault(x => x.Id == id);

            if (image == null)
                throw new NullOrEmptyDomainDataException("image mot found");

            Images.Remove(image);
        }
        public void Edit(string title, Money money)
        {
            Guard(title);
            Title = title;
            Money = money;
        }
        private void Guard(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        }
    }
}

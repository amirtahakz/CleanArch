using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Edit
{
    public class EditProductCommand : IRequest
    {
        public EditProductCommand(Guid id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}

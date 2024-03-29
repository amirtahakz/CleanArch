﻿using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        private OrderItem()
        {

        }
        public OrderItem(Guid orderId , Guid productId , int count , Money price)
        {
            OrderId = orderId;
            ProductId = productId;
            Price = price;
            Count = count;
        }
        public Guid OrderId { get; protected set; }
        public Guid ProductId { get; private set; }
        public int Count { get; private set; }
        public Money Price { get; private set; }
    }
}

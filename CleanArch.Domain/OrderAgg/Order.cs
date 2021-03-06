using CleanArch.Domain.OrderAgg;
using CleanArch.Domain.OrderAgg.Events;
using CleanArch.Domain.OrderAgg.Services;
using CleanArch.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.OrderAgg
{
    public class Order : AggregateRoot
    {
        public Guid UserId { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime FinallyDate { get; private set; }

        public int TotalPrice;
        public ICollection<OrderItem> Items{ get; set; }
        public int TotalItems { get; set; }

        public Order(Guid userId)
        {
            UserId = userId;
        }
        public void Finally()
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;
            AddDomainEvent(new OrderFinalized(Id , UserId));
        }
        public void AddItem(Guid productId , int count , int price , IOrderDomainService orderService)
        {
            if (!orderService.IsProductExist(productId))
                throw new Exception("ss");

            Items.Add(new OrderItem(Id , productId ,count , Money.FromTooman(price)));
            TotalItems += count;
        }
        public void RemoveItem(Guid productId)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);
            if (item == null)
                throw new Exception("Sth");

            Items.Remove(item);
            TotalItems -= item.Count;
        }
    }
}

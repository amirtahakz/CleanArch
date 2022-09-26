using CleanArch.Contracts;
using CleanArch.Domain.ProductAgg.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.EventHandlers
{
    public class ProductCreatedSendSmsEventHndler : INotificationHandler<ProductCreated>
    {
        private readonly ISmsService _smsService;

        public ProductCreatedSendSmsEventHndler(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _smsService.SendSms(new SmsBody());
            await Task.CompletedTask;
        }
    }
}

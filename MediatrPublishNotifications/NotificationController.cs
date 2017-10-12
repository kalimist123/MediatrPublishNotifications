using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPublishNotifications
{
    public class NotificationController :BaseController
    {
        private readonly IMediator _mediator;


        public NotificationController(IMediator mediator,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this._mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {
            
            return View();
        }


        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
             _mediator.Publish(new DomainNotification("Commit", "We had a problem during saving your data."));

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(customerViewModel);
        }

    }
}

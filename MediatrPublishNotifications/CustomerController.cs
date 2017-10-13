using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPublishNotifications
{
    public class CustomerController :BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            _customerAppService.Register(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Registered!";

            return View(customerViewModel);
        }
        [HttpGet]
      
        public IActionResult Edit(int id)
        {
          

          //  var customerViewModel = _customerAppService.GetById(id.Value);


            var customerViewModel = new CustomerViewModel
            {
                Id=Guid.NewGuid(),
                BirthDate = DateTime.Now,
                Name = "JimBob",
                Email = "mick@mokc.com"
            };

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }



        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
           // if (!ModelState.IsValid) return View(customerViewModel);

            _customerAppService.Update(customerViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Customer Updated!";

            return View(customerViewModel);
        }

    }
}

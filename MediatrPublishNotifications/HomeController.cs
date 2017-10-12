using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatrPublishNotifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPublishNotifications
{

public class HomeController : Controller
{

    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    public async Task<IActionResult> Index()
    {
        await _mediator.Publish(new SomeEvent("Hello World"));
        return View();
    }


    public async Task<IActionResult> Create()
    {
       
        return View();
    }
        // more code omitted
    }
}

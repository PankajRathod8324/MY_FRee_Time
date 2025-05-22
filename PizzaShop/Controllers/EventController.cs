using System.Diagnostics;
using System.Security.Claims;
using DAL.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities.ViewModel;
using X.PagedList.Extensions;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Interfaces;

namespace PizzaShop.Controllers;


public class EventController : Controller
{
    // private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;
    private readonly ITaxService _taxService;

    // ILogger<HomeController> logger
    public EventController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    public IActionResult AddEvent()
    {
        return View();
    }

    public IActionResult CheckAvailability(EventVM eventData)
    {
        // bool IsAvailable = 

        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
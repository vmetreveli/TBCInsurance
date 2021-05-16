﻿using System.Diagnostics;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;
namespace InventoryManagement.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index() =>
            View();

        public IActionResult Privacy() =>
            View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
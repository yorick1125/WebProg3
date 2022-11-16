using DutchTreats.Data;
using DutchTreats.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;
        private readonly IDutchRepository _repository;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ApplicationDbContext context, IDutchRepository repository)
        {
            _logger = logger;
            _emailSender = emailSender;
            _db = context;
            _repository = repository;
        }

        public IActionResult Shop()
        {
            // Get all products from the database using LINQ
            var results = _db.Products
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        [HttpPost("Contact")]
        public async Task<IActionResult> ContactAsync(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                await _emailSender.SendEmailAsync(contact.Email, contact.Topic, contact.Message);

                // Call the view success and send the contact model
                return View("Success", contact);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

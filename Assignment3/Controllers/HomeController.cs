using Assignment3.Data;
using Assignment3.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";


            return View();
        }

        [HttpPost("contact")]
        public async Task<IActionResult> Contact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {

                string body = "";
                body += contact.FirstName + "\n";
                body += contact.LastName + "\n";
                body += contact.PostalCode + "\n";
                body += contact.Email + "\n";
                body += DateTime.Now + "\n";
                body += contact.Topic + "\n";
                body += contact.Comments + "\n";
                body += contact.Phone + "\n";

                // send the email
                await _emailSender.SendEmailAsync(contact.Email, contact.Topic, body);
                await _emailSender.SendEmailAsync("2021web3@gmail.com", contact.Topic, body);

                // store in database
                _db.Add(contact);
                _db.SaveChanges();

                // return the view.
                return View("Success", contact);
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

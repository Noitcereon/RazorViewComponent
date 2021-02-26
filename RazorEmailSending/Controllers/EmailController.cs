using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService;

namespace RazorEmailSending.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendEmail(EmailModel email)
        {
            
            if (email != null)
            {
                _emailSender.SendEmail(email);
            }
            return View(nameof(Index));
        }
    }
}

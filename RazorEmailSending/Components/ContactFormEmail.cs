using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService;
using Microsoft.AspNetCore.Mvc;

namespace RazorEmailSending.Components
{
    public class ContactFormEmail : ViewComponent
    {
        private readonly IEmailSender _emailSender;

        public ContactFormEmail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IViewComponentResult Invoke(EmailModel email)
        {
            if (email != null)
            {
                _emailSender.SendEmail(email);
            }
            return View();
        }
    }
}

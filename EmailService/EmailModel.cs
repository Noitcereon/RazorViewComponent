using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MimeKit;

namespace EmailService
{
    public class EmailModel
    {
        [Required]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public EmailModel(string to, string subject, string body)
        {
            //To = new List<MailboxAddress>();

            //To.AddRange(to.Select(x => new MailboxAddress(x)));
            To = to;
            Subject = subject;
            Body = body;
        }

        public EmailModel()
        { }
        
    }
}

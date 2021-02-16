using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService.EmailService;
using EmailService.Models;

namespace EmailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public readonly IEmail emailService;
        public EmailController(IEmail emailService)
        {
            this.emailService = emailService;
        }

        [HttpPost("setup")]
        public IActionResult SetupEmailService(AdminEmailDetails emailDetails)
        {
            if (emailDetails.EmailAddress != null || emailDetails.Password != null)
            {
                emailService.SetupService(emailDetails.EmailAddress, emailDetails.Password);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("send")]
        public IActionResult SendEmail(EmailMessage message)
        {
            if (message.UserEmail != null)
            {
                emailService.SendMail(message.UserEmail, message.Subject, message.BodyText);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

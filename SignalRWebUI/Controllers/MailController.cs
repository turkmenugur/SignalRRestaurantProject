﻿using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("UT Restoran Rezervasyon", "trkmn.ugur.12@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("Alıcı", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("trkmn.ugur.12@gmail.com", "nqow jeob ukcp xiwd");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}

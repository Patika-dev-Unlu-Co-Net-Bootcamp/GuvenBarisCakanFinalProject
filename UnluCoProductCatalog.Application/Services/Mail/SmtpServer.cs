﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace UnluCoProductCatalog.Application.Services.Mail
{
    //public class SmtpServer :ISmtpServer
    //{
    //    private readonly IConfiguration _configuration;
    //    public SmtpServer(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }

    //    public SmtpClient GetSmtpClient()
    //    {
    //        var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
    //        {
    //            Port = int.Parse(_configuration["Smtp:Port"]),
    //            Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
    //            EnableSsl = true
    //        };

    //        return smtpClient;
    //    }
    //}
}

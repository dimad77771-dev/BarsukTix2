using BarsukTix.Data.Entities;
using BarsukTix.Services.DTO;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BarsukTix.Services.Implementations
{
    public class EmailSender : IEmailSender
    {
        async Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var file = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var path = Path.Combine(@"C:\Tmp\_______emails", file);
            var text = email + "\n\n" + subject + "\n\n" + htmlMessage;
            File.WriteAllText(path, text);
        }
    }
}


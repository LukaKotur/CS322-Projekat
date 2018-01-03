using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS322_Projekat.Services.Email

{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
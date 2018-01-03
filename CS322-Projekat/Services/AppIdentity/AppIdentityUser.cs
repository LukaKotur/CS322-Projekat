using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CS322_Projekat.AppIdentity
{
    public class AppIdentityUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
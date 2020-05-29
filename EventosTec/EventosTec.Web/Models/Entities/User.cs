using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosTec.Web.Models.Entities
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

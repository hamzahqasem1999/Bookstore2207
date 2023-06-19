using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Models
{
    public class Applicationuser:IdentityUser
    {
        public string Name { get; set; }
        public DateTime Bdate { get; set; }

    }
}

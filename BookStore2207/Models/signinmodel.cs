using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Models
{
    public class signinmodel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public bool rememberme { get; set; }

    }
}

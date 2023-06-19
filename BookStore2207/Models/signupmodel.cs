using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Models
{
    public class signupmodel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime  Bdate { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        [Compare("confirmpassword")]
        public string password { get; set; }
        
        public string confirmpassword { get; set; }

    }
}

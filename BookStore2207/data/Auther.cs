using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.data
{
    [Table("auther")]
    public class Auther
    {
        public int Id { get; set; }
        [Required]

        public string firstname { get; set; }
        [Required]

        public string lastname { get; set; }
        [Required]

        public string Nationality { get; set; }

        public string path { get; set; }
        [NotMapped]
        public IFormFile image { get; set; }


        public List<Bookstore> libookes { get; set; }


    }
}

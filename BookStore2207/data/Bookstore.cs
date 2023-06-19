using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.data
{
    [Table("BookStore")]
    public class Bookstore
    {
        public int Id { get; set; }
        [Required]
        public string booktitle { get; set; }
        [Required]

        public int year { get; set; }
        [Required]

        public string prise { get; set; }
        public Category catgory { get; set; }
        [ForeignKey("Catgory")]
        public int category_Id { get; set; }
        public Auther auther { get; set; }

        [ForeignKey("Auther")]

        public int auther_Id { get; set; }
        public string path { set; get; }

        [NotMapped]
        public IFormFile image { set; get; }
        public int stock { get; set; }



    }
}

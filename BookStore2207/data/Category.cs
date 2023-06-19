using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.data
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public int code { get; set; }
        [Required]

        public string Name { get; set; }
        public List<Bookstore> libookes { set; get; }


    }
}

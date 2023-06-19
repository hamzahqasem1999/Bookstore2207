using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore2207.data;
namespace BookStore2207.Models
{
    public class vmbook
    {
        public Bookstore bookstore { get; set; }
        public List<Category> licategories { get; set; }
        public List<Auther> liAuther { get; set; }

    }
}

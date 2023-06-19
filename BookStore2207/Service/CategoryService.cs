using BookStore2207.data;
using BookStore2207.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
    public class CategoryService: ICategoryService
    {
        BookContext context;

        public CategoryService(BookContext _context)
        {
            context = _context;
        }


        public void insert(Category category)
        {

            context.categories.Add(category);
            context.SaveChanges();

        }
        public void update(Category category)
        {

            context.categories.Attach(category);
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        public List<Category> loadall()
        {
            List<Category> li = context.categories.ToList();



            return li;
        }
        public List<Category> loadbyname(string name)
        {

            List<Category> li = context.categories.Where(p => p.Name == name).ToList();

            return li;
        }

        public void delete(int id)
        {
            Category category = context.categories.Find(id);
            context.categories.Remove(category);
            context.SaveChanges();


        }
        public Category load(int id)
        {

            return context.categories.Find(id);

        }
    }
}

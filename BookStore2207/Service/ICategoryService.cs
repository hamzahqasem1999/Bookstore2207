using BookStore2207.data;
using BookStore2207.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
   public interface ICategoryService
    {
        void insert(Category category);
        void update(Category category);
        List<Category> loadall();
        List<Category> loadbyname(string name);
        void delete(int id);
        Category load(int id);
    }
}

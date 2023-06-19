using BookStore2207.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
   public interface IBookService
    {
        void insert(Bookstore bookstore);
        void update(Bookstore bookstore);
        List<Bookstore> loadall();
        List<Bookstore> loadbyname(string name);
        void delete(int id);
        List<Bookstore> loadauth(int auth_id);
        Bookstore load(int id);
    }
}

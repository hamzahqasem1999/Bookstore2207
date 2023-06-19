using BookStore2207.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
    public class BookService: IBookService
    {
        BookContext context;

        public BookService(BookContext _context)
        {
            context = _context;
        }

        public void insert(Bookstore bookstore)
        {

            context.bookstores.Add(bookstore);
            context.SaveChanges();

        }
        public void update(Bookstore bookstore)
        {

            context.bookstores.Attach(bookstore);
            context.Entry(bookstore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        public List<Bookstore> loadall()
        {
            List<Bookstore> li = context.bookstores.ToList();

            return li;
        }

        public List<Bookstore> loadbyname(string name)
        {

            List<Bookstore> li = context.bookstores.Where(p => p.booktitle == name).ToList();

            return li;
        }

        public void delete(int id)
        {
            Bookstore bookstore = context.bookstores.Find(id);
            context.bookstores.Remove(bookstore);
            context.SaveChanges();

        }

        public List<Bookstore> loadauth(int auth_id)
        {

            return context.bookstores.Where(d => d.auther_Id == auth_id).ToList();
        }

        public Bookstore load(int id)
        {

            return context.bookstores.Find(id);

        }
    }
}

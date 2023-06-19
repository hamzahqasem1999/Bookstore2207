using BookStore2207.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
    public class AutherService : IAutherService
    {
         BookContext context;

        public AutherService(BookContext _context){
            context = _context;
        }
        public void insert(Auther auther)
        {

            context.authers.Add(auther);
            context.SaveChanges();

        }
        public void update(Auther auther)
        {

            context.authers.Attach(auther);
            context.Entry(auther).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

        }

        public List<Auther> loadall()
        {
            List<Auther> li = context.authers.ToList();



            return li;
        }
        public List<Auther> loadbyname(string name)
        {

            List<Auther> li = context.authers.Where(p => p.firstname == name).ToList();

            return li;
        }

        public void delete(int id)
        {
            Auther auther = context.authers.Find(id);
            context.authers.Remove(auther);
            context.SaveChanges();


        }

        public Auther load(int id)
        {

            return context.authers.Find(id);

        }
    }
}

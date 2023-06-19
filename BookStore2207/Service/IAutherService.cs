using BookStore2207.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Service
{
  public interface IAutherService
    {
        void insert(Auther auther);
        void update(Auther auther);
        List<Auther> loadall();
        List<Auther> loadbyname(string name);
        void delete(int id);
        Auther load(int id);
    }
}

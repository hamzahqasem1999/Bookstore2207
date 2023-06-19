using BookStore2207.data;
using BookStore2207.Models;
using BookStore2207.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Controllers
{
    [Authorize]
    public class BookstoreController : Controller
    {
         IBookService bookService;
        ICategoryService categoryService;
         IAutherService autherService;
         IConfiguration config;
        BookContext context;

        public BookstoreController(IBookService _bookService,ICategoryService _categoryService,IAutherService _autherService,IConfiguration _config,BookContext _context)
        {
            bookService = _bookService;
            categoryService = _categoryService;
            autherService = _autherService;
            config = _config;
            context = _context;
        }
     


        public IActionResult Index()
        {
            vmbook vm = new vmbook();

            vm.licategories = categoryService.loadall();
            vm.liAuther = autherService.loadall();
            

            ViewData["IsEdited"] = false;
            return View("Newbook", vm);


        }


        public IActionResult save(vmbook vm)

        {
            //if (ModelState.IsValid == true)
            //{
                string name = Guid.NewGuid().ToString() + "." + vm.bookstore.image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
                vm.bookstore.image.CopyTo(new FileStream(path, FileMode.Create));
                vm.bookstore.path = name;
                bookService.insert(vm.bookstore);
            //}


            ViewData["IsEdited"] = false;

            vm.licategories = categoryService.loadall();
            vm.liAuther = autherService.loadall();


            return View("Newbook",vm);

        }

        public IActionResult update(vmbook vm)

        {
            if (ModelState.IsValid == true)
            {
                if (vm.bookstore.image != null)
                {
                    string name = Guid.NewGuid().ToString() + "." + vm.bookstore.image.FileName.Split('.')[1];
                    string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
                    vm.bookstore.image.CopyTo(new FileStream(path, FileMode.Create));
                    vm.bookstore.path = name;
                }

                ViewData["IsEdited"] = true;
                bookService.update(vm.bookstore);
            }


            vm.licategories = categoryService.loadall();
            vm.liAuther = autherService.loadall();


            return View("Newbook", vm);

        }


        public IActionResult booksearch()
        {
            List<Bookstore> li = bookService.loadall();
            return View("booklist", li);

        }


        public IActionResult search()
        {

            string name = Request.Form["booktitle"];
            List<Bookstore> li = bookService.loadbyname(name);

            return View("booklist", li);

        }

        public IActionResult delete(int id)
        {


            Bookstore bookstore = context.bookstores.Find(id);
            context.bookstores.Remove(bookstore);
            context.SaveChanges();


            List<Bookstore> li = bookService.loadall();



            return View("booklist", li);
        }

        public IActionResult loadauth(int auth_id)
        {
            List<Bookstore> li = bookService.loadauth(auth_id);

            return View("booklist", li);
        }

        public IActionResult edit(int id)
        {
            vmbook vm = new vmbook();
            Bookstore bookstore = bookService.load(id);
            vm.bookstore = bookstore;



            vm.licategories = categoryService.loadall();
            vm.liAuther = autherService.loadall();


            ViewData["IsEdited"] = true;

            return View("Newbook", vm);
        }

        //public IActionResult loadcity(int country_id)

        //{

        //    List<city> li = cityservice.loadcites(country_id);
        //    return Json(li);
        //}
    }
}

using BookStore2207.data;
using BookStore2207.Models;
using BookStore2207.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Controllers
{
    public class CatgoryController : Controller
    {
         ICategoryService categoryService;

        public  CatgoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            ViewData["IsEdited"] = false;
            return View("Newcategory");
        }



        public IActionResult save(Category categ)
        {
            categoryService.insert(categ);

            return View("Newcategory");
        }


        public IActionResult update(Category c)

        {

            categoryService.update(c);
            ViewData["IsEdited"] = true;

            return View("Newcategory", c);

        }
        public IActionResult categsearch()
        {
            List<Category> li = categoryService.loadall();

            return View("Categorylist", li);

        }

        public IActionResult edit(int Id)

        {

            Category categ = new Category();
            Category category = categoryService.load(Id);
            categ = category;

            ViewData["IsEdited"] = true;
            return View("Newcategory", categ);

        }



        public IActionResult search()
        {

            string name = Request.Form["txtname"];
            List<Category> li = categoryService.loadbyname(name);

            return View("Categorylist", li);


        }
        public IActionResult delete(int id)
        {


            categoryService.delete(id);
            List<Category> li = categoryService.loadall();
            return View("Categorylist", li);
        }

    }
}

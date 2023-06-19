using BookStore2207.data;
using BookStore2207.Models;
using BookStore2207.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Controllers
{
    public class AutherController : Controller
    {
       IAutherService autherService;
         IConfiguration config;

        public AutherController(IAutherService _autherService,IConfiguration _config)
        {
            autherService = _autherService;
            config = _config;
        }
        public IActionResult Index()
        {
            ViewData["IsEdited"] = false;
            return View("NewAuther");
        }


        public IActionResult save(VmAuther vm)

        {
            //if (ModelState.IsValid == true)
            //{
            string name = Guid.NewGuid().ToString() + "." + vm.auther.image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
            vm.auther.image.CopyTo(new FileStream(path, FileMode.Create));
            vm.auther.path = name;
            autherService.insert(vm.auther);
            //}


            ViewData["IsEdited"] = false;

          


            return View("NewAuther", vm);

        }



        public IActionResult update(Auther vm)

        {
            if (ModelState.IsValid == true)
            {
                if (vm.image != null)
                {
                    string name = Guid.NewGuid().ToString() + "." + vm.image.FileName.Split('.')[1];
                    string path = Path.Combine(Directory.GetCurrentDirectory(), config["ImageFolderName"], name);
                    vm.image.CopyTo(new FileStream(path, FileMode.Create));
                    vm.path = name;
                }

                ViewData["IsEdited"] = true;
                autherService.update(vm);
            }


            //vm.licity = cityservice.loadall();
            //vm.licountry = countryservice.loadall();
            //vm.lidepartment = departmentservice.loadall();


            return View("NewAuther", vm);

        }

        public IActionResult authsearch()
        {
            List<Auther> li = autherService.loadall();

            return View("autherlist", li);

        }

        //public IActionResult edit(int id)

        //{

        //    department dept = new department();
        //    department department = departmentservice.load(id);
        //    dept = department;

        //    ViewData["IsEdited"] = true;
        //    return View("newdepartment", dept);

        //}



        public IActionResult search()
        {

            string name = Request.Form["txtname"];
            List<Auther> li = autherService.loadbyname(name);

            return View("autherlist", li);


        }
        public IActionResult delete(int id)
        {


            autherService.delete(id);
            List<Auther> li = autherService.loadall();
            return View("autherlist", li);
        }




        public IActionResult edit(int id)
        {
            Auther vm = new Auther();
            Auther auther = autherService.load(id);
            vm = auther;



         
          
      

            ViewData["IsEdited"] = true;

            return View("NewAuther", vm);
        }
    }
}

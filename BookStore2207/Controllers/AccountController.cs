using BookStore2207.Models;
using BookStore2207.service;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.Controllers
{
  
    public class AccountController : Controller
    {

        IAccountservice accountservice;
        public AccountController(IAccountservice _accountservice)
        {

           accountservice = _accountservice;


        }
        public IActionResult Index()
        {
            return View("CreateAccount");
        }

        public async Task<IActionResult> CreateAccount(signupmodel signup )
        {
         var result= await   accountservice.CreateAccount(signup);
            ViewData["Message"] = result;
            return View("CreateAccount");
        }

        public IActionResult Login()
        {


            return View("signin");
        }


      //  [Authorize(Roles = "Admin")]
        public IActionResult newrole()
        {


            return View("newrole");
        }
        public async Task<IActionResult> checkpassword(signinmodel signinmodel)
        {
         var result=  await accountservice.signin(signinmodel);
            if (result.Succeeded == true)
            {

                return RedirectToAction("Index", "Bookstore");

            }
            else
            {

                ViewData["messege"] = " Invalid username or password";
                return View("signin");
            }
            
        }
             
        public async Task<IActionResult> addrole( rolemodel rolemodel)
        {

            var result = await accountservice.addrole(rolemodel);
            return View("newrole");
        }

       // [Authorize(Roles = "Admin")]
        public IActionResult getusers()
        {
            List<Applicationuser> li = accountservice.getusers();
            return View("userslist",li);
        }


        public async Task< IActionResult> usersrole(string userid ,string name)
        {
            ViewData["name"] = name;
          List<userroles> liuserroles= await  accountservice.getroles(userid);

            return View(liuserroles);
        }



        public async Task<IActionResult> updateuserrole(List<userroles> liuserrole)
        {
            
            await  accountservice.updateuserrole(liuserrole);
            List<userroles> liuserroles = await accountservice.getroles(liuserrole[0].userid);


            return View("usersrole", liuserroles);
         
        }
        public IActionResult Logout()
        {
            accountservice.Logout();

            return View("signin");

        }


    }
}

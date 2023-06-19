using BookStore2207.Models;

using BookStore2207.service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore2207.service
{
    public class Accountservice:IAccountservice

    {
       
       
        UserManager<Applicationuser> userManager;
        SignInManager<Applicationuser> signinmanger;
        RoleManager<IdentityRole> roleManager;
        public Accountservice(UserManager<Applicationuser> _userManger , SignInManager<Applicationuser> _signinmanger ,RoleManager<IdentityRole> _roleManager)
        {

            userManager = _userManger;
            signinmanger = _signinmanger;
            roleManager = _roleManager;
        }


        public async Task< IdentityResult> CreateAccount(signupmodel signup)
        {

            Applicationuser user = new Applicationuser();
          
            user.UserName = signup.username;
            user.Email = signup.email;
            user.Name = signup.name;
            user.Bdate = signup.Bdate;
          //  user.PasswordHash = signup.password;

           var result= await  userManager.CreateAsync(user,signup.password);
            return result;
        }





        public async Task <SignInResult> signin(signinmodel si)
        {
   

            var result= await  signinmanger.PasswordSignInAsync(si.username, si.password, si.rememberme, false);
            return result;
          
        }


        public async Task<IdentityResult> addrole(rolemodel rolemodel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = rolemodel.name;
            var result = await roleManager.CreateAsync(role);
            return result;
        }



        public List<Applicationuser> getusers()
        {
            List<Applicationuser> li= userManager.Users.ToList();
            return li;
        }
        public async Task Logout()
        {

            await signinmanger.SignOutAsync();

            }

        public async  Task <List<userroles>> getroles(string userid)
        {
            List<IdentityRole> lirole = roleManager.Roles.ToList();
            List<userroles> liuserrole = new List<userroles>();
            foreach (IdentityRole item in lirole)
            {
                userroles urole = new userroles();
                urole.roleid = item.Id;
                urole.rolename = item.Name;
                urole.userid = userid;
                urole.isselected = false;
                liuserrole.Add(urole);

            }
            foreach (userroles uR in liuserrole)
            {
              var user= await   userManager.FindByIdAsync(uR.userid);
             var roles=  await  userManager.GetRolesAsync(user);

                foreach (string r in roles)
                {
                    if (r == uR.rolename)
                    {
                        uR.isselected = true;                    
                    }
                
                }
            }

            return liuserrole;
        }

        public async Task updateuserrole(List<userroles> liuserrole)
        {

            foreach (userroles item in liuserrole)
            {

                var user = await userManager.FindByIdAsync(item.userid);
                if (item.isselected == true)

                {

                    if(await userManager.IsInRoleAsync(user, item.rolename)== false)
                    { 
                    await userManager.AddToRoleAsync(user, item.rolename);
                    }
                }
                else
                {
                    if (await userManager.IsInRoleAsync(user, item.rolename) == true)
                    {
                        await userManager.RemoveFromRoleAsync(user, item.rolename);
                    }
                }
            }
        
        }

    }
}

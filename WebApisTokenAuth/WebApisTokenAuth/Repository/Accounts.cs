using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApisTokenAuth.Models;

namespace WebApisTokenAuth.Repository
{
    public class Accounts: ApplicationDbContexts
    {

        //Varifying user credentials
        public bool Login(string userName, string password)
        {
            try
            {

                var userInfo = ApplicationDbContext.ApplicationUsers.Where(x => x.UserName == userName).FirstOrDefault();
                if (userInfo != null)
                {
                    string stringPwd = userInfo.Password;
                    return stringPwd == password;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //regitering new 
        public bool Register(ApplicationUser userData)
        {
            try
            {
                //register new user
                ApplicationDbContext.ApplicationUsers.Add(userData);
                ApplicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //To get user role provided with username
        public string GetUserRole(string userName)
        {
            return ApplicationDbContext.ApplicationUsers.Where(x => x.UserName == userName).Select(y => y.UserRole.RoleName).FirstOrDefault();
        }

        public List<string> GetUserRoles()
        {
            return ApplicationDbContext.UserRoles.Select(x => x.RoleName).ToList();
        }

    }
}
using System.Text;
using System.Web.Http;
using WebApisTokenAuth.Models;
using WebApisTokenAuth.Repository;

namespace WebApisTokenAuth.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {

        [HttpGet]
        [Route("NoAuth")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult NoAuth()
        {
            Accounts userRoles = new Accounts();
            return Ok(userRoles.GetUserRoles());
        }

        [HttpGet]
        [Route("AuthorizedUser")]
        [Authorize(Roles ="Admin")]
        public IHttpActionResult AuthorizedUser()
        {
            Accounts userRoles = new Accounts();
            return Ok(userRoles.GetUserRoles());
        }

        [HttpPost]
        [Route("AuthenticatedUser")]
        [Authorize]
        public IHttpActionResult AuthenticatedUser()
        {
            Employees emp = new Employees();
            return Ok(emp.GetEmployees());
        }

        [HttpPost]
        [Route("PostUserData")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult PostData([FromBody]Models.User userData)
        {
            Accounts regObj = new Accounts();
            ApplicationUser regData = new ApplicationUser();
            regData.EmailID = userData.EmailID;
            regData.Password = userData.Password;
            regData.UserName = userData.UserName;
            regData.RoleId = userData.RoleId;

            return Ok(regObj.Register(regData));
        }

    }
}

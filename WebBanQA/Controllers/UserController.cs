using Microsoft.AspNetCore.Mvc;
using WebBanQA.Models;

namespace WebBanQA.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("api/login/{username}/{password}")]
        public bool Login(string username, string password)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var res = db.Users.Where(x => x.UName == username && x.UPass == password).FirstOrDefault();
            if (res == null)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        [Route("api/register")]
        public string Register(string fname, string lname, string uname, string password, string email, string phonenumber, string address)
        {
            try
            {
                QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
                User user = new User();

                var checkUserName = db.Users.Where(x => x.UName == uname).SingleOrDefault();
                var checkEmail = db.Users.Where(x => x.UEmail == email).SingleOrDefault();
                var checkPhoneNumber = db.Users.Where(x => x.UContact == phonenumber).SingleOrDefault();

                if (checkUserName != null)
                {
                    return "Username exist";
                }
                else if (checkEmail != null)
                {
                    return "Email exist";
                }
                else if (checkPhoneNumber != null)
                {
                    return "Phone number exist";
                }
                else
                {
                    // insert new user
                    user.UId = "";
                    user.UFname = fname;
                    user.ULname = lname;
                    user.UName = uname;
                    user.UEmail = email;
                    user.UStatus = "true";
                    user.UAdd = address;
                    user.UContact = phonenumber;
                    user.UCreated = DateTime.Now;
                    user.UPass = password;
                    db.Users.Add(user);
                    db.SaveChanges();

                    return "Success";
                }
            }
            catch
            {
                return "Fail";
            }
        }

        [HttpGet]
        [Route("api/checkAccount")]
        public string checkAccountExist(string username)
        {
            QLCuaHangBanQAContext db = new QLCuaHangBanQAContext();
            var checkUserName = db.Users.Where(x => x.UName == username).SingleOrDefault();
            var checkEmail = db.Users.Where(x => x.UEmail == username).SingleOrDefault();
            if (checkUserName != null)
            {
                return checkUserName.UName.ToString();
            }
            else if (checkEmail != null)
            {
                return checkEmail.UEmail.ToString();
            }
            else
            {
                return "NOT EXIST";
            }
        }
    }
}

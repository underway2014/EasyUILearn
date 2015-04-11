using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EasyUILearn.Models;
namespace EasyUILearn.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult DoLogin(string name,string passWord)
        {
            UserManagerDBContext db = new UserManagerDBContext();

            int result = 1;
            List<UserModel> userList = db.UserModels.Where(m => m.Name == name && m.PassWord == passWord).ToList();
            if(userList.Count == 0)
            {
                result = 0;//
            }
            return Content(result.ToString());
        }
	}
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyUILearn.Models;

namespace EasyUILearn.Controllers
{
    public class UserManagerController : Controller
    {
        private UserManagerDBContext db = new UserManagerDBContext();

        // GET: /UserManager/
        public ActionResult Index()
        {

           // return Json(db.UserModels.ToList(), JsonRequestBehavior.AllowGet);
            return View(db.UserModels.ToList());
        }
        public ActionResult ShowUser()
        {
            return Json(db.UserModels.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: /UserManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModels.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // GET: /UserManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserManager/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,PassWord")] UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                db.UserModels.Add(usermodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usermodel);
        }
        [HttpPost]
        public ActionResult AddUser()
        {
            int res = 1;
            String name = Request.Form["name"];
            String pwd = Request.Form["passWord"];
            if(name == "" || pwd == "")
            {
                res = -1;
            }
            else
            {
                UserModel u = new UserModel();
                u.Name = name;
                u.PassWord = pwd;
                db.UserModels.Add(u);
                db.SaveChanges();
               // return RedirectToAction("Index");
            }
            return Content(res.ToString());
        }
        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            int res = 1;
            
            List<UserModel> userList = db.UserModels.Where(m => m.Id == userId).ToList();
            if(userList.Count > 0)
            {
                db.UserModels.Remove(userList[0]);
                int line = db.SaveChanges();
                if(line < 0)
                {
                    res = -1;
                }
            }

            return Content(res.ToString());
        }
        // GET: /UserManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModels.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // POST: /UserManager/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,PassWord")] UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usermodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usermodel);
        }

        // GET: /UserManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel usermodel = db.UserModels.Find(id);
            if (usermodel == null)
            {
                return HttpNotFound();
            }
            return View(usermodel);
        }

        // POST: /UserManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserModel usermodel = db.UserModels.Find(id);
            db.UserModels.Remove(usermodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

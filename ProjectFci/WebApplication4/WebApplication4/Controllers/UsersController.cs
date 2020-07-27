//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebApplication4.Dto;
//using WebApplication4.Logic;
//using WebApplication4.Models;

//namespace WebApplication4.Controllers
//{
//    public class UsersController : Controller
//    {
//        private  UserLogic _Iuser;
//        public UsersController()
//        {
//            _Iuser = new UserLogic();
//        }
//        // GET: Users
//        public ActionResult GetAll()
//        {
//            return View(_Iuser.GetAll());
//        }

//        // GET: Users/Details/5
//        public ActionResult Details(long id)
//        {
            
//            UserDto user = _Iuser.GetById(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // GET: Users/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Users/Create
        
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create( UserDto user)
//        {
//            if (ModelState.IsValid)
//            {
//                _Iuser.Insert(user);
//                return RedirectToAction("Index");
//            }

//            return View(user);
//        }

//        // GET: Users/Edit/5
//        public ActionResult Edit(long id)
//        {
//            UserDto user = _Iuser.GetById(id);

//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Edit/5
      
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(UserDto user)
//        {
//            if (ModelState.IsValid)
//            { 
//               _Iuser.Update(user,user.ID);

//            return RedirectToAction("Index");
//            }
//            return View(user);
//        }

//        // GET: Users/Delete/5
//        public ActionResult Delete(long id)
//        {
           
//            UserDto user = _Iuser.GetById(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(long id)
//        {
//        _Iuser.Delete(id);

//            return RedirectToAction("Index");
//        }

      
//    }
//}

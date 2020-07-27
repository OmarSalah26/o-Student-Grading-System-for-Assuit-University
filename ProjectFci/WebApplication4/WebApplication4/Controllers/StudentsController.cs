using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Dto;
using WebApplication4.Logic;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class StudentsController : Controller
    {
private readonly StudentLogic _Istudent;
        public StudentsController()
        {
         _Istudent=new StudentLogic();
    }

        // GET: Students
        public ActionResult GetAll()
        {
            try
            {
                return View(_Istudent.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        // GET: Students/Details/5
        public ActionResult Details(long StudentSeatingNumber)
        {
            try
            {

                StudentDto student = _Istudent.GetById(StudentSeatingNumber); ;
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Create
        public ActionResult Create()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // POST: Students/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDto student)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Istudent.Insert(student);
                    return RedirectToAction("GetAll");
                }

                return View(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Edit/5
        public ActionResult Edit(long StudentSeatingNumber)
        {
            try
            {
                
                StudentDto student = _Istudent.GetById(StudentSeatingNumber); ;
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // POST: Students/Edit/5
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( StudentDto student)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _Istudent.Update(student, student.SeatingNumber);

                    return RedirectToAction("Index");
                }
                return View(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Delete/5
        public ActionResult Delete(long StudentSeatingNumber)
        {
            try
            {

                StudentDto student = _Istudent.GetById(StudentSeatingNumber); ;

                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long StudentSeatingNumber)
        {
            try
            {

                _Istudent.Delete(StudentSeatingNumber); ;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      
    }
}

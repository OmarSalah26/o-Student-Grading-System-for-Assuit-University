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
    public class SubjectsController : Controller
    {
       
        private SubjectLogic _subjectLogic;
        public SubjectsController()
        {
            _subjectLogic = new SubjectLogic();
           
        }
  
        // GET: Subjects
        public ActionResult GetAll()
        {
            try
            {
                return View(_subjectLogic.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Subjects/Details/5
        public ActionResult Details(string SubjectCode)
        {
            try
            {

                SubjectDto subject = _subjectLogic.GetById(SubjectCode);
                if (subject == null)
                {
                    return HttpNotFound();
                }
                return View(subject);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Subjects/Create
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectDto subjectDto, List<long> Evaluations, List<long> Rates)
        {
            try
            {

                _subjectLogic.Insert(subjectDto, Evaluations, Rates);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(string subjectcode)
        {
            try
            {

                SubjectDto subject = _subjectLogic.GetById(subjectcode);
                if (subject == null)
                {
                    return HttpNotFound();
                }
                return View(subject);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Subjects/Edit/5
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SubjectDto subject)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _subjectLogic.Update(subject);
                    return RedirectToAction("Index");
                }

                return View(subject);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(string subjectcode)
        {
            try
            {

                SubjectDto subject = _subjectLogic.GetById(subjectcode);
                if (subject == null)
                {
                    return HttpNotFound();
                }
                return View(subject);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string subjectcode)
        {
            try
            {

                _subjectLogic.Delete(subjectcode);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      
    }
}

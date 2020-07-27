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
    public class StudentYearPatchesController : Controller
    {
        private StudentYearPatchLogic _studentYearPatchesLogic;
        public StudentYearPatchesController()
        {
            _studentYearPatchesLogic = new StudentYearPatchLogic();
        }
        // GET: StudentYearPatches
        public ActionResult Index()
        {
            try
            {
                return View(_studentYearPatchesLogic.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        // GET: StudentYearPatches/Details/5
        public ActionResult Details(long PatchID, long YearId, long StudentsId)
        {
            try
            {

                StudentYearPatchDto studentYearPatch = _studentYearPatchesLogic.GetById(PatchID, YearId, StudentsId);
                if (studentYearPatch == null)
                {
                    return HttpNotFound();
                }
                return View(studentYearPatch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: StudentYearPatches/Create
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

        // POST: StudentYearPatches/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentYearPatchDto studentYearPatch)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _studentYearPatchesLogic.Insert(studentYearPatch);
                    return RedirectToAction("Index");
                }

                return View(studentYearPatch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: StudentYearPatches/Edit/5
        public ActionResult Edit(long PatchID, long YearId, long StudentsId)
        {
            try
            {

                StudentYearPatchDto studentYearPatch = _studentYearPatchesLogic.GetById(PatchID, YearId, StudentsId);
                if (studentYearPatch == null)
                {
                    return HttpNotFound();
                }

                return View(studentYearPatch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: StudentYearPatches/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( StudentYearPatchDto studentYearPatch)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _studentYearPatchesLogic.Update(studentYearPatch, studentYearPatch.PatchID, studentYearPatch.YearID, studentYearPatch.StudentSeatingNumber);
                    return RedirectToAction("Index");
                }

                return View(studentYearPatch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: StudentYearPatches/Delete/5
        public ActionResult Delete(long PatchID, long YearId, long StudentsId)
        {
            try
            {

                StudentYearPatchDto studentYearPatch = _studentYearPatchesLogic.GetById(PatchID, YearId, StudentsId);
                if (studentYearPatch == null)
                {
                    return HttpNotFound();
                }
                return View(studentYearPatch);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: StudentYearPatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long PatchID, long YearId, long StudentsId)
        {
            try
            {

                _studentYearPatchesLogic.Delete(PatchID, YearId, StudentsId);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Dto;
using WebApplication4.Logic;

namespace WebApplication4.Controllers
{
    public class StudentEnrollSubjectController:Controller
    {

        private readonly StudentEnrollSubjectsLogic _StudentEnrollSubjectsLogic;
        public StudentEnrollSubjectController()
        {
            _StudentEnrollSubjectsLogic =new StudentEnrollSubjectsLogic() ;
        }



        // GET: Students
        public ActionResult GetAll()
        {
            try
            {
                return View(_StudentEnrollSubjectsLogic.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Details/5
        public ActionResult Details(string subjectcode, long StudentSeatingNumber)
        {
            try
            {

                StudentEnrollSubjectDto studentEnrollSubjects = _StudentEnrollSubjectsLogic.GetById(subjectcode, StudentSeatingNumber); ;
                if (studentEnrollSubjects == null)
                {
                    return HttpNotFound();
                }
                return View(studentEnrollSubjects);
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
        public ActionResult Create(StudentEnrollSubjectDto student,List<string> subjectcodes)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _StudentEnrollSubjectsLogic.Insert(student, subjectcodes);
                    return RedirectToAction("GetAll");

                }

                return RedirectToAction("GetAll", "Subjects");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Edit/5
        public ActionResult Edit(string subjectcode, long StudentSeatingNumber)
        {
            try
            {

                StudentEnrollSubjectDto StudentEnrollSubjects = _StudentEnrollSubjectsLogic.GetById(subjectcode, StudentSeatingNumber); ;
                if (StudentEnrollSubjects == null)
                {
                    return HttpNotFound();
                }
                return View(StudentEnrollSubjects);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Students/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentEnrollSubjectDto studentEnrollSubjectDto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _StudentEnrollSubjectsLogic.Update(studentEnrollSubjectDto);

                    return RedirectToAction("GetAll", "Subjects");
                }
                return View(studentEnrollSubjectDto);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Students/Delete/5
        public ActionResult Delete(string subjectcode, long StudentSeatingNumber)
        {
            try
            {

                StudentEnrollSubjectDto StudentEnrollSubject = _StudentEnrollSubjectsLogic.GetById(subjectcode, StudentSeatingNumber); ;

                if (StudentEnrollSubject == null)
                {
                    return HttpNotFound();
                }
                return View(StudentEnrollSubject);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string subjectcode, long StudentSeatingNumber)
        {
            try
            {

                _StudentEnrollSubjectsLogic.Delete(subjectcode, StudentSeatingNumber); ;

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}
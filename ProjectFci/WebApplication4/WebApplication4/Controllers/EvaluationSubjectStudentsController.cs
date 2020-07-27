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
    public class EvaluationSubjectStudentsController : Controller
    {
        private readonly EvaluationSubjectStudentLogic _evaluationSubjectStudents;
        SubjectLogic _subjectLogic;
        public EvaluationSubjectStudentsController()
        {
            _evaluationSubjectStudents = new EvaluationSubjectStudentLogic();
            _subjectLogic = new SubjectLogic();
        }

        // GET: EvaluationSubjectStudents
        public ActionResult Index(string id)
        {
            try
            {
                TempData["id"] = id;
                var subject = _subjectLogic.GetById(id);
                TempData["subject"] = subject;

                return View(subject);

            }
            catch (Exception ex)
            {

                return View(TempData["subject"]);
            }
        }

        public ActionResult DetailsSelectSubject()
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
        // GET: EvaluationSubjectStudents/Details/5
        //لرصد ردجا الطلاب لماده معينه
        public ActionResult Details(string id)
        {
            try
            {
               

                
                return View(_subjectLogic.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      

        // POST: EvaluationSubjectStudents/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(params EvaluationSubjectStudentDto[][] Grades)
        {
            try
            {
                if (Grades == null)
                {
                  return  RedirectToAction("index", "Home");
                }

                if (ModelState.IsValid)
                {
                    foreach (var Students in Grades)
                    {
                        foreach (var evaluations in Students)
                        {
                            _evaluationSubjectStudents.Insert(evaluations);
                        }

                    }
                    
                    return RedirectToAction("Index", "EvaluationSubjectStudents",new { id = Grades[0][0].subjectcode });
                }


                return View(Grades);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: EvaluationSubjectStudents/Edit/5
        public ActionResult Edit( string id)
        {
            try
            {

                if (id != null)
                {
                    TempData["id"] = id;
                }
                else
                   id = TempData["id"] as string;

                return View(_subjectLogic.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: EvaluationSubjectStudents/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(params EvaluationSubjectStudentDto[][] Grades)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    foreach (var Students in Grades)
                    {
                        foreach (var evaluationSubjectStudent in Students)
                        {
                            _evaluationSubjectStudents.Update(evaluationSubjectStudent, evaluationSubjectStudent.EvaluationID,
                       evaluationSubjectStudent.subjectcode, evaluationSubjectStudent.StudentSeatingNumber);
                        }

                        
                    }
                    return RedirectToAction("Index", "EvaluationSubjectStudents", new { id = Grades[0][0].subjectcode });
                }
                return View(_subjectLogic.GetById(TempData["id"] as string));
               
            
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "EvaluationSubjectStudents", new { id = TempData["id"] as string });
            }

        }

        // GET: EvaluationSubjectStudents/Delete/5
        public ActionResult Delete(long EvaluationId, string subjectcode, long StudentsId)
        {
            try
            {

                EvaluationSubjectStudentDto evaluationSubjectStudent = _evaluationSubjectStudents.GetById(EvaluationId, subjectcode, StudentsId);
                if (evaluationSubjectStudent == null)
                {
                    return HttpNotFound();
                }
                return View(evaluationSubjectStudent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: EvaluationSubjectStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long EvaluationId, string SubjectId, long StudentsId)
        {
            try
            {
                _evaluationSubjectStudents.Delete(EvaluationId, SubjectId, StudentsId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }
        [ActionName("ClacTotalDegreeForSubject")]
        public ActionResult ClacTotalDegreeForSubject(params double[] degrees) {
            TempData["Sum"] = degrees.Sum();
            string subjectID = TempData["SubjectID"] as string;
            return RedirectToAction("Details", "EvaluationSubjectStudents",new { id = subjectID });
        }

    
    }
}

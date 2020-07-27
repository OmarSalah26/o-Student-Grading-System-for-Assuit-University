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
    public class SubjectEvaluationsController : Controller
    {
        private SubjectEvaluationLogic _subjectEvaluationLogic;
        public SubjectEvaluationsController()
        {
            _subjectEvaluationLogic = new SubjectEvaluationLogic();
        }
        //
        // GET: SubjectEvaluations
        public ActionResult Index()
        {
            try
            {
                return View(_subjectEvaluationLogic.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        // GET: SubjectEvaluations/Details/5
        public ActionResult Details(long EvaluationId, string SubjectId)
        {
            try
            {

                SubjectEvaluationDto subjectEvaluation = _subjectEvaluationLogic.GetById(EvaluationId, SubjectId);
                if (subjectEvaluation == null)
                {
                    return HttpNotFound();
                }
                return View(subjectEvaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectEvaluations/Create
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

        // POST: SubjectEvaluations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectEvaluationDto subjectEvaluation)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _subjectEvaluationLogic.Insert(subjectEvaluation);
                    return RedirectToAction("Index");
                }


                return View(subjectEvaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectEvaluations/Edit/5
        public ActionResult Edit(long EvaluationId, string SubjectId)
        {
            try
            {

                SubjectEvaluationDto subjectEvaluation = _subjectEvaluationLogic.GetById(EvaluationId, SubjectId);
                if (subjectEvaluation == null)
                {
                    return HttpNotFound();
                }

                return View(subjectEvaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: SubjectEvaluations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectEvaluationDto subjectEvaluation)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _subjectEvaluationLogic.Update(subjectEvaluation, subjectEvaluation.EvaluationId, subjectEvaluation.subjectcode);
                    return RedirectToAction("Index");
                }

                return View(subjectEvaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: SubjectEvaluations/Delete/5
        public ActionResult Delete(long EvaluationId, string SubjectId)
        {
            try
            {

                SubjectEvaluationDto subjectEvaluation = _subjectEvaluationLogic.GetById(EvaluationId, SubjectId);
                if (subjectEvaluation == null)
                {
                    return HttpNotFound();
                }
                return View(subjectEvaluation);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // POST: SubjectEvaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long EvaluationId, string SubjectId)
        {
            try
            {

                _subjectEvaluationLogic.Delete(EvaluationId, SubjectId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

      
    }
}

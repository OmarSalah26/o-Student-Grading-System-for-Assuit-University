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
    public class LogFilesController : Controller
    {
        private LogFileLogic _logfile;
        public LogFilesController()
        {
            _logfile = new LogFileLogic();
           
        }

        // GET: LogFiles
        public ActionResult GetAll()
        {
            try
            {
                return View(_logfile.GetAll());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: LogFiles/Details/5
        public ActionResult Details(long id)
        {
            try
            {

                LogFileDto logFile = _logfile.GetById(id);
                if (logFile == null)
                {
                    return HttpNotFound();
                }
                return View(logFile);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        

        // POST: LogFiles/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LogFileDto logFile)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _logfile.Insert(logFile);
                    return RedirectToAction("Index");
                }

                return View(logFile);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

       
  
        
    }
}

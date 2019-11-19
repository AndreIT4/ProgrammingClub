using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class AnnouncementController : Controller
    {

        private Repository.AnnouncementRepository announcementRepository = new Repository.AnnouncementRepository();
       
        
        
        // GET: Announcement

        public ActionResult Index()
        {
            return View();
        }

        // GET: Announcement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Announcement/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: Announcement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //instantiem modelul
                Models.AnnouncementModel announcementModel = new Models.AnnouncementModel();

                //incarcam datele in model

                UpdateModel(announcementModel);

                announcementRepository.InsertAnnouncement(announcementModel);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: Announcement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Announcement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

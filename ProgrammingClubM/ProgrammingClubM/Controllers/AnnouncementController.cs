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
            List<Models.AnnouncementModel> announcements = announcementRepository.GetAllAnnouncements();
            return View("Index", announcements);
        }

        // GET: Announcement/Details/5
        public ActionResult Details(Guid id)
        {
            Models.AnnouncementModel announcementModel = announcementRepository.GetAnnouncementByID(id);


            return View("AnnouncementDetails", announcementModel);
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

                Models.AnnouncementModel announcementModel = new Models.AnnouncementModel();

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
        public ActionResult Edit(Guid id)
        {
            Models.AnnouncementModel announcementModel = announcementRepository.GetAnnouncementByID(id);

            return View("EditAnnouncement", announcementModel);
        }

        // POST: Announcement/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Models.AnnouncementModel announcementModel = new Models.AnnouncementModel();

                UpdateModel(announcementModel);

                announcementRepository.UpdateAnnouncement(announcementModel);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditAnnouncement");
            }
        }

        // GET: Announcement/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.AnnouncementModel announcementModel = announcementRepository.GetAnnouncementByID(id);
            return View("DeleteAnnouncement", announcementModel);
        }

        // POST: Announcement/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                announcementRepository.DeleteAnnouncement(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteAnnouncement");
            }
        }
    }
}

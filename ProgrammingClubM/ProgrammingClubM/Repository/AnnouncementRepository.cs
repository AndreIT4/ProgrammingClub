using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Models;
using ProgrammingClubM.Mappers;


namespace ProgrammingClubM.Repository
{
    public class AnnouncementRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;

        public Guid Id { get; private set; }

        public AnnouncementRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public AnnouncementRepository(Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AnnouncementModel> GetAllAnnouncements()
        {
            List<AnnouncementModel> announcements = new List<AnnouncementModel>();

            foreach (Models.DBObjects.Announcement announcement in dbContext.Announcements)
            {
                announcements.Add(announcement.MapObject<AnnouncementModel>());
            }
            return announcements;

        }

        public AnnouncementModel GetMemberByID(Guid ID)
        {
            Models.DBObjects.Announcement existingAnnouncement = dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == ID);
            if (existingAnnouncement != null)
                return existingAnnouncement.MapObject<AnnouncementModel>();
            else
                return null;


        }

        public void InsertAnnouncement(AnnouncementModel announcement)
        {
            announcement.IDAnnouncement = Guid.NewGuid();
            dbContext.Announcements.InsertOnSubmit(announcement.MapObject<Models.DBObjects.Announcement>());
            dbContext.SubmitChanges();
        }

        public AnnouncementModel GetAnnouncementByID(Guid id)
        {
            Models.DBObjects.Announcement existingAnnouncement = dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == id);
            if (existingAnnouncement != null)
                return existingAnnouncement.MapObject<AnnouncementModel>();
            else
                return null;
        }

        public void UpdateAnnouncement(AnnouncementModel announcementModel)
        {
            Models.DBObjects.Announcement existingannouncement = dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == announcementModel.IDAnnouncement);

            if (existingannouncement != null)
            {
                existingannouncement.UpdateObject(announcementModel);
                dbContext.SubmitChanges();
            }
        }

        public void DeleteAnnouncement(Guid ID)
        {
            Models.DBObjects.Announcement announcementToDelete = dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == ID);
            if (announcementToDelete != null)
            {
                
                dbContext.Announcements.DeleteOnSubmit(announcementToDelete);
                dbContext.SubmitChanges();



            }
        }


    }
}
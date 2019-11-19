using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Models;

namespace ProgrammingClubM.Repository
{
    public class AnnouncementRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;

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
            List<AnnouncementModel> announcemetList = new List<AnnouncementModel>();

            foreach (Models.DBObjects.Announcement dbAnnouncement in dbContext.Announcements)
            {
                announcemetList.Add(MapDbObjectToModel(dbAnnouncement));
            }
            return announcemetList;

        }

        public AnnouncementModel GetAnnoucementByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == ID));

        }



        public List<AnnouncementModel> GetAnnouncementModelsByEffectiveDates(DateTime validFrom, DateTime validTo)
        {
            List<AnnouncementModel> announcementList = new List<AnnouncementModel>();

            foreach (Models.DBObjects.Announcement dbAnnouncement in dbContext.Announcements.Where(x => x.ValidFrom >= validFrom && x.ValidTo <= validTo))
            {
                announcementList.Add(MapDbObjectToModel(dbAnnouncement));
            }

            return announcementList;
        }

        public List<AnnouncementModel> GetAnnouncementsByEventDate(DateTime eventDate)
        {
            List<AnnouncementModel> announcementsList = new List<AnnouncementModel>();

            foreach (Models.DBObjects.Announcement dbAnnouncement in dbContext.Announcements.Where(x => x.EventDateTime.HasValue && x.EventDateTime.Value.Date == eventDate.Date))
            {
                announcementsList.Add(MapDbObjectToModel(dbAnnouncement));
            }
            return announcementsList;
        }


        public void InsertAnnouncement(AnnouncementModel announcementModel)
        {
            announcementModel.IDAnnouncement = Guid.NewGuid();

            dbContext.Announcements.InsertOnSubmit(MapModelToDbObject(announcementModel));
            dbContext.SubmitChanges();
        }


        public void UpdateAnnouncement(AnnouncementModel announcementModel)
        {
            Models.DBObjects.Announcement existingAnnouncement = dbContext.Announcements.FirstOrDefault(x => x.IDAnnouncement == announcementModel.IDAnnouncement);

            if (existingAnnouncement != null)
            {
                existingAnnouncement.IDAnnouncement = announcementModel.IDAnnouncement;
                existingAnnouncement.ValidFrom = announcementModel.ValidFrom;
                existingAnnouncement.ValidTo = announcementModel.ValidTo;
                existingAnnouncement.Title = announcementModel.Title;
                existingAnnouncement.Text = announcementModel.Text;
                existingAnnouncement.EventDateTime = announcementModel.EventDateTime;
                existingAnnouncement.Tags = announcementModel.Tags;
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

        private AnnouncementModel MapDbObjectToModel(Models.DBObjects.Announcement dbAnnouncement)
        {
            AnnouncementModel announcementModel = new AnnouncementModel();

            if (dbAnnouncement != null)
            {
                announcementModel.IDAnnouncement = dbAnnouncement.IDAnnouncement;
                announcementModel.ValidFrom = dbAnnouncement.ValidFrom;
                announcementModel.Title = dbAnnouncement.Title;
                announcementModel.Text = dbAnnouncement.Text;
                announcementModel.EventDateTime = dbAnnouncement.EventDateTime;
                announcementModel.Tags = dbAnnouncement.Tags;

                return announcementModel;
            }
            return null;
        }

        private Models.DBObjects.Announcement MapModelToDbObject(AnnouncementModel announcementModel)
        {
            Models.DBObjects.Announcement dbAnouncementModel = new Models.DBObjects.Announcement();

            if (announcementModel != null)
            {
                dbAnouncementModel.IDAnnouncement = announcementModel.IDAnnouncement;
                dbAnouncementModel.ValidFrom = announcementModel.ValidFrom;
                dbAnouncementModel.ValidTo = announcementModel.ValidTo;
                dbAnouncementModel.Title = announcementModel.Title;
                dbAnouncementModel.Text = announcementModel.Text;
                dbAnouncementModel.EventDateTime = announcementModel.EventDateTime;
                dbAnouncementModel.Tags = announcementModel.Tags;
                return dbAnouncementModel;
            }
            return null;
        }

    }

}
















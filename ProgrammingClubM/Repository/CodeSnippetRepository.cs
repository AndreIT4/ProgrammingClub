using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Models;

namespace ProgrammingClubM.Repository
{
    public class CodeSnippetRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;

        public CodeSnippetRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public CodeSnippetRepository(Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CodeSnippetModel> GetAllCodeSnippets()
        {
            List<CodeSnippetModel> codeSnippetList = new List<CodeSnippetModel>();

            foreach (Models.DBObjects.CodeSnippet dbCodeSnippet in dbContext.CodeSnippets)
            {
                codeSnippetList.Add(MapDbObjectToModel(dbCodeSnippet));
            }
            return codeSnippetList;

        }

        public CodeSnippetModel GetCodeSnippetByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == ID));

        }



        public List<CodeSnippetModel> GetCodeSnippetModelsByAddedDate(DateTime addedDate)
        {
            List<CodeSnippetModel> codeSnippetList = new List<CodeSnippetModel>();

            foreach (Models.DBObjects.CodeSnippet dbCodeSnippet in dbContext.CodeSnippets.Where(x => x.DateTimeAdded == addedDate))
            {
                codeSnippetList.Add(MapDbObjectToModel(dbCodeSnippet));
            }

            return codeSnippetList;
        }

        public List<CodeSnippetModel> GetPublishedCodeSnipped(bool isPublished)
        {
            List<CodeSnippetModel> codeSnippetList = new List<CodeSnippetModel>();

            foreach (Models.DBObjects.CodeSnippet dbCodeSnippet in dbContext.CodeSnippets.Where(x => x.IsPublished==isPublished))
            {
                codeSnippetList.Add(MapDbObjectToModel(dbCodeSnippet));
            }
            return codeSnippetList;
        }


        public void InsertCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IDCodeSnippet = Guid.NewGuid();

            dbContext.CodeSnippets.InsertOnSubmit(MapModelToDbObject(codeSnippetModel));
            dbContext.SubmitChanges();
        }


        public void UpdateAnnouncement(CodeSnippetModel codeSnippetModel)
        {
            Models.DBObjects.CodeSnippet existingCodeSnippet = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == codeSnippetModel.IDCodeSnippet);

            if (existingCodeSnippet != null)
            {
               
                existingCodeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                existingCodeSnippet.Title = codeSnippetModel.Title;
                existingCodeSnippet.ContentCode = codeSnippetModel.ContentCode;
                existingCodeSnippet.IDMember = codeSnippetModel.IDMember;
                existingCodeSnippet.Revision = codeSnippetModel.Revision;
                existingCodeSnippet.IDSnippetPreviousVersion = codeSnippetModel.IDSnippetPreviousVersion;
                existingCodeSnippet.DateTimeAdded = codeSnippetModel.DateTimeAdded;
                existingCodeSnippet.IsPublished = codeSnippetModel.IsPublished;
                dbContext.SubmitChanges();
            }
        }

        public void DeleteCodeSnippet(Guid ID)
        {
            Models.DBObjects.CodeSnippet codeSnippetToDelete = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == ID);

            if (codeSnippetToDelete != null)
            {
                dbContext.CodeSnippets.DeleteOnSubmit(codeSnippetToDelete);
                dbContext.SubmitChanges();
            }
        }

        private CodeSnippetModel MapDbObjectToModel(Models.DBObjects.CodeSnippet dbCodeSnippet)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();

            if (dbCodeSnippet != null)
            {
                codeSnippetModel.IDCodeSnippet = dbCodeSnippet.IDCodeSnippet;
                codeSnippetModel.Title = dbCodeSnippet.Title;
                codeSnippetModel.ContentCode = dbCodeSnippet.ContentCode;
                codeSnippetModel.IDMember = dbCodeSnippet.IDMember;
                codeSnippetModel.Revision = dbCodeSnippet.Revision;
                codeSnippetModel.IDSnippetPreviousVersion = dbCodeSnippet.IDSnippetPreviousVersion;
                codeSnippetModel.DateTimeAdded = dbCodeSnippet.DateTimeAdded;
                codeSnippetModel.IsPublished = dbCodeSnippet.IsPublished;


                return codeSnippetModel; ;
            }
            return null;
        }

        private Models.DBObjects.CodeSnippet MapModelToDbObject(CodeSnippetModel codeSnippetModel)
        {
            Models.DBObjects.CodeSnippet dbCodeSnippetModel = new Models.DBObjects.CodeSnippet();

            if (codeSnippetModel != null)
            {
                
                dbCodeSnippetModel.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                dbCodeSnippetModel.Title = codeSnippetModel.Title;
                dbCodeSnippetModel.ContentCode = codeSnippetModel.ContentCode;
                dbCodeSnippetModel.IDMember = codeSnippetModel.IDMember;
                dbCodeSnippetModel.Revision = codeSnippetModel.Revision;
                dbCodeSnippetModel.IDSnippetPreviousVersion = codeSnippetModel.IDSnippetPreviousVersion;
                dbCodeSnippetModel.DateTimeAdded = codeSnippetModel.DateTimeAdded;
                dbCodeSnippetModel.IsPublished = codeSnippetModel.IsPublished;
                return dbCodeSnippetModel;
            }
            return null;
        }
    }
}
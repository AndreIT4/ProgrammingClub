using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Models;
using ProgrammingClubM.Mappers;


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
            List<CodeSnippetModel> codeSnippets = new List<CodeSnippetModel>();

            foreach (Models.DBObjects.CodeSnippet codeSnippet in dbContext.CodeSnippets)
            {
                codeSnippets.Add(codeSnippet.MapObject<CodeSnippetModel>());
            }
            return codeSnippets;

        }

        public CodeSnippetModel GetCodeSnippetByID(Guid ID)
        {
            Models.DBObjects.CodeSnippet existingCodeSnippet = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == ID);
            if (existingCodeSnippet != null)
                return existingCodeSnippet.MapObject<CodeSnippetModel>();
            else
                return null;


        }

        public void InsertCodeSnippet(CodeSnippetModel codeSnippet)
        {
            codeSnippet.IDCodeSnippet = Guid.NewGuid();
            dbContext.CodeSnippets.InsertOnSubmit(codeSnippet.MapObject<Models.DBObjects.CodeSnippet>());
            dbContext.SubmitChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            Models.DBObjects.CodeSnippet existingcodeSnippet = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == codeSnippetModel.IDCodeSnippet);

            if (existingcodeSnippet != null)
            {
                existingcodeSnippet.UpdateObject(codeSnippetModel);
                dbContext.SubmitChanges();
            }
        }

        public void DeleteCodeSnippet(Guid ID)
        {
            Models.DBObjects.CodeSnippet codeSnippetToDelete = dbContext.CodeSnippets.FirstOrDefault(x => x.IDCodeSnippet == ID);
            if (codeSnippetToDelete != null)
            {
                dbContext.CodeSnippets.DeleteAllOnSubmit<Models.DBObjects. CodeSnippet>(codeSnippetToDelete.CodeSnippets);
                dbContext.CodeSnippets.DeleteAllOnSubmit<Models.DBObjects.CodeSnippet>(codeSnippetToDelete.CodeSnippets);
                dbContext.CodeSnippets.DeleteOnSubmit(codeSnippetToDelete);
                dbContext.SubmitChanges();



            }
        }


    }
}
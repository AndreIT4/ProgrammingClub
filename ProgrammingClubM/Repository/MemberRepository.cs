using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Models;
using ProgrammingClubM.Mappers;


namespace ProgrammingClubM.Repository
{
    public class MemberRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;

        public MemberRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public MemberRepository(Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MemberModel> GetAllMembers()
        {
            List<MemberModel> members = new List<MemberModel>();

            foreach (Models.DBObjects.Member member in dbContext.Members)
            {
                members.Add(member.MapObject<MemberModel>());
            }
            return members;

        }

        public MemberModel GetMemberByID(Guid ID)
        {
            Models.DBObjects.Member existingMember = dbContext.Members.FirstOrDefault(x => x.IDMember == ID);
            if (existingMember != null)
                return existingMember.MapObject<MemberModel>();
            else
                return null;


        }

        public void InsertMember(MemberModel member)
        {
            member.IDMember = Guid.NewGuid();
            dbContext.Members.InsertOnSubmit(member.MapObject<Models.DBObjects.Member>());
            dbContext.SubmitChanges();
        }

        public void UpdateMember(MemberModel memberModel)
        {
            Models.DBObjects.Member existingmember = dbContext.Members.FirstOrDefault(x => x.IDMember == memberModel.IDMember);

            if (existingmember != null)
            {
                existingmember.UpdateObject(memberModel);
                dbContext.SubmitChanges();
            }
        }

        public void DeleteMember(Guid ID)
        {
            Models.DBObjects.Member memberToDelete = dbContext.Members.FirstOrDefault(x => x.IDMember == ID);
            if (memberToDelete != null)
            {
                dbContext.Memberships.DeleteAllOnSubmit<Models.DBObjects.Membership>(memberToDelete.Memberships);
                dbContext.CodeSnippets.DeleteAllOnSubmit<Models.DBObjects.CodeSnippet>(memberToDelete.CodeSnippets);
                dbContext.Members.DeleteOnSubmit(memberToDelete);
                dbContext.SubmitChanges();



            }
        }


    }      
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Mappers;
using ProgrammingClubM.Models;

namespace ProgrammingClubM.Repository
{
    public class MembershipTypeRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;
       

        public MembershipTypeRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public MembershipTypeRepository (Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public List<MembershipTypeModel> GetAllMembers()
        {
            List<MembershipTypeModel> membershipTypes = new List<MembershipTypeModel>();

            foreach(Models.DBObjects.MembershipType membershipType in dbContext.MembershipTypes)
            {
                membershipTypes.Add(membershipType.MapObject<MembershipTypeModel>());
            }
            return membershipTypes;
        }

        public MembershipTypeModel GetMembershipTypeByID(Guid ID)
        {
            Models.DBObjects.MembershipType existingMember = dbContext.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == ID);

            if (existingMember != null)
                return existingMember.MapObject<MembershipTypeModel>();
            else
                return null;
        }

        public void InsertMembershipType(MembershipTypeModel member)
        {
            member.IDMembershipType = Guid.NewGuid();

            dbContext.MembershipTypes.InsertOnSubmit(member.MapObject<Models.DBObjects.MembershipType>());
            dbContext.SubmitChanges();
        }
        public void UpdateMembershiptype(MembershipTypeModel membershipTypeModel)
        {
            Models.DBObjects.MembershipType exisitngmembershipType = dbContext.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == membershipTypeModel.IDMembershipType);
            if (exisitngmembershipType != null)
            {
                exisitngmembershipType.UpdateObject(membershipTypeModel);
                dbContext.SubmitChanges();
            }
        }

        public void DeleteMembershipType(Guid ID)
        {
            Models.DBObjects.MembershipType membershipTypeToDelete = dbContext.MembershipTypes.FirstOrDefault(x => x.IDMembershipType == ID);

            if (membershipTypeToDelete != null)
            {
                dbContext.Memberships.DeleteAllOnSubmit<Models.DBObjects.Membership>(membershipTypeToDelete.Memberships);
                dbContext.MembershipTypes.DeleteOnSubmit(membershipTypeToDelete);
                dbContext.SubmitChanges();
            }
        }

    }
}
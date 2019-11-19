using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingClubM.Mappers;
using ProgrammingClubM.Models;

namespace ProgrammingClubM.Repository
{
    public class MembershipRepository
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;


        public MembershipRepository()
        {
            this.dbContext = new Models.DBObjects.ClubMembershipModelsDataContext();
        }

        public MembershipRepository(Models.DBObjects.ClubMembershipModelsDataContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public List<MembershipModel> GetAllMemberships()
        {
            List<MembershipModel> memberships = new List<MembershipModel>();

            foreach (Models.DBObjects.Membership membership in dbContext.Memberships)
            {
                memberships.Add(membership.MapObject<MembershipModel>());
            }
            return memberships;
        }

        public MembershipModel GetMembershipTypeByID(Guid ID)
        {
            Models.DBObjects.Membership existingMember = dbContext.Memberships.FirstOrDefault(x => x.IDMembership == ID);

            if (existingMember != null)
                return existingMember.MapObject<MembershipModel>();
            else
                return null;
        }

        public void InsertMember(MembershipModel membership)
        {
            membership.IDMembership = Guid.NewGuid();

            dbContext.Memberships.InsertOnSubmit(membership.MapObject<Models.DBObjects.Membership>());
            dbContext.SubmitChanges();
        }
        public void UpdateMember(MembershipModel membershipModel)
        {
            Models.DBObjects.Membership exisitngmembership = dbContext.Memberships.FirstOrDefault(x => x.IDMembership == membershipModel.IDMembershipType);
            if (exisitngmembership != null)
            {
                exisitngmembership.UpdateObject(membershipModel);
                dbContext.SubmitChanges();
            }
        }

        public void DeleteMember(Guid ID)
        {
            Models.DBObjects.Membership membershipToDelete = dbContext.Memberships.FirstOrDefault(x => x.IDMembership == ID);

            if (membershipToDelete != null)
            {


                dbContext.Memberships.DeleteOnSubmit(membershipToDelete);
                dbContext.SubmitChanges();
            }
        }

    }
}
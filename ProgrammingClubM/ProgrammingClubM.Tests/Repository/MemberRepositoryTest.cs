using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingClubM.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using ProgrammingClubM.Repository;
using ProgrammingClubM.Tests.Utility;
using ProgrammingClubM.Models.DBObjects;
using ProgrammingClubM.Models;

namespace ProgrammingClubM.Tests
{
    public class MemberRepositoryTest
    {
        private Models.DBObjects.ClubMembershipModelsDataContext dbContext;
        private string testDbConnectionString;

        private MemberRepository memberRepository;

        public void Initialize()
        {
            testDbConnectionString = ConfigurationManager.ConnectionStrings["ProgrammingClubM.Tests.Properties.Settings.clubmembershiptestsConnectiongString"].ConnectionString;
            dbContext = new Models.DBObjects.ClubMembershipModelsDataContext(testDbConnectionString);

            memberRepository = new MemberRepository(dbContext);
        }

        public void TestCleanup()
        {
            dbContext.Members.DeleteAllOnSubmit(dbContext.Members);
            dbContext.SubmitChanges();
        }

        public void GetAllMembers_TwoRecordsExists()
        {
            Member member1 = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description1",
                Name = "name1",
                Position = "phd1",
                Resume = string.Empty,
                Title = "title1"
            };

            Member member2 = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description2",
                Name = " name2",
                Position = "phd2",
                Resume = string.Empty,
                Title = "title2"
            };

            dbContext.Members.InsertOnSubmit(member1);
            dbContext.Members.InsertOnSubmit(member2);
            dbContext.SubmitChanges();

            List<MemberModel> result = memberRepository.GetAllMembers();

            Assert.AreEqual(2, result.Count);

            AssertUtility.AssertAreEqual(member1, result[0]);
            AssertUtility.AssertAreEqual(member2, result[1]);

        }

        public void GetMemberByID_MemberExists()
        {
            
            Guid ID = Guid.NewGuid();
            Member expectedMember = new Member
            {
                IDMember = ID,
                Description = "description1",
                Name = "name1",
                Position = "phd1",
                Resume = string.Empty,
                Title = "title1"
            };
            Member member2 = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description2",
                Name = "name2",
                Position = "phd2",
                Resume = string.Empty,
                Title = "title2"
            };
            dbContext.Members.InsertOnSubmit(expectedMember);
            dbContext.Members.InsertOnSubmit(member2);
            dbContext.SubmitChanges();
            
            MemberModel result = memberRepository.GetMemberByID(ID);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(ID, result.IDMember);
            AssertUtility.AssertAreEqual(expectedMember, result);
        }

        public void InsertMember()
        {
            
            MemberModel memberModel = new MemberModel
            {
                IDMember = Guid.NewGuid(),
                Description = "description1",
                Name = "name1",
                Position = "phd1",
                Resume = string.Empty,
                Title = "title1"
            };
            memberRepository.InsertMember(memberModel);
            
            Member dbMember = dbContext.Members.FirstOrDefault(x => x.IDMember == memberModel.IDMember);
            Assert.IsNotNull(dbMember);
        }

        public void UpdateAnnouncement_RecordExists()
        {
            
            Guid ID = Guid.NewGuid();
            Member member1 = new Member
            {
                IDMember = ID,
                Description = "description1",
                Name = "name1",
                Position = "phd1",
                Resume = string.Empty,
                Title = "title1"
            };
            Member member2 = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description2",
                Name = "name2",
                Position = "phd2",
                Resume = string.Empty,
                Title = "title2"
            };
            dbContext.Members.InsertOnSubmit(member1);
            dbContext.Members.InsertOnSubmit(member2);
            dbContext.SubmitChanges();
            MemberModel memberModelToUpdate = new MemberModel
            {
                IDMember = ID,
                Description = "descriptionupdate",
                Name = "nameupdate",
                Position = "phdupdate",
                Resume = string.Empty,
                Title = "titleupdate"
            };
            
            memberRepository.UpdateMember(memberModelToUpdate);
            
            Member dbMember = dbContext.Members.FirstOrDefault(x => x.IDMember == ID);
            Assert.IsNotNull(dbMember);
            Assert.AreEqual(member1, dbMember);
            Member dbMemberNotUpdated = dbContext.Members.FirstOrDefault(x => x.IDMember == member2.IDMember);
            Assert.IsNotNull(dbMemberNotUpdated);
            Assert.AreEqual(member2, dbMemberNotUpdated);
        }

        public void DeleteMember_RecordExists()
        {
            
            Guid ID = Guid.NewGuid();
            Member expectedMember = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description1",
                Name = "name1",
                Position = "phd1",
                Resume = string.Empty,
                Title = "title2"
            };
            Member member2 = new Member
            {
                IDMember = Guid.NewGuid(),
                Description = "description2",
                Name = "name2",
                Position = "phd2",
                Resume = string.Empty,
                Title = "title2"
            };

            dbContext.Members.InsertOnSubmit(expectedMember);
            dbContext.Members.InsertOnSubmit(member2);
            dbContext.SubmitChanges();
            
            memberRepository.DeleteMember(ID);
            
            Member dbMember = dbContext.Members.FirstOrDefault(x => x.IDMember == ID);
            Assert.IsNull(dbMember);
            Member dbMemberNotUpdated = dbContext.Members.FirstOrDefault(x => x.IDMember == member2.IDMember);
            Assert.IsNotNull(dbMemberNotUpdated);
        }
    }


}



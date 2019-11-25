using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class MembershipController : Controller
    {
        private Repository.MembershipRepository membershipRepository = new Repository.MembershipRepository();

        // GET: Membership
        public ActionResult Index()
        {
            List<Models.MembershipModel> memberships = membershipRepository.GetAllMemberships();

            return View("Index", memberships);
        }

        // GET: Membership/Details/5
        public ActionResult Details(Guid id)
        {
            Models.MembershipModel membershipModel = membershipRepository.GetMembershipsByID(id);

            return View("MembershipDetails", membershipModel);
        }

        // GET: Membership/Create
        public ActionResult Create()
        {
            return View("CreateMembership");
        }

        // POST: Membership/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MembershipModel membershipModel = new Models.MembershipModel();

                UpdateModel(membershipModel);

                membershipRepository.InsertMembership(membershipModel);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMembership");
            }
        }

        // GET: Membership/Edit/5
        public ActionResult Edit(Guid id)
        {
            Models.MembershipModel membershipModel = membershipRepository.GetMembershipsByID(id);
            return View("EditMembership", membershipModel);
        }

        // POST: Membership/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Models.MembershipModel membershipModel = new Models.MembershipModel();

                UpdateModel(membershipModel);

                membershipRepository.UpdateMembership(membershipModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMembership");
            }
        }

        // GET: Membership/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.MembershipModel membershipModel = membershipRepository.GetMembershipsByID(id);

            return View("DeleteMembership", membershipModel);
        }

        // POST: Membership/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                membershipRepository.DeleteMembership(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteMembership");
            }
        }
    }
}

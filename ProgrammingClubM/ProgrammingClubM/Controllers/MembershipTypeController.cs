using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class MembershipTypeController : Controller
    {

        private Repository.MembershipTypeRepository membershipTypeRepository = new Repository.MembershipTypeRepository();

        // GET: MembershipType
        public ActionResult Index()
        {
            List<Models.MembershipTypeModel> membershipTypes = membershipTypeRepository.GetAllMembershipTypes();
            return View("Index", membershipTypes);
        }

        // GET: MembershipType/Details/5
        public ActionResult Details(Guid id)
        {
            Models.MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);

            return View("MembershipTypeDetails", membershipTypeModel);
        }

        // GET: MembershipType/Create
        public ActionResult Create()
        {
            return View("CreateMembershipType");
        }

        // POST: MembershipType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MembershipTypeModel membershipTypeModel = new Models.MembershipTypeModel();

                UpdateModel(membershipTypeModel);

                membershipTypeRepository.InsertMembershipType(membershipTypeModel);


                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMembershipType");
            }
        }

        // GET: MembershipType/Edit/5
        public ActionResult Edit(Guid id)
        {
            Models.MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);

            return View("EditMembershipType", membershipTypeModel);
        }

        // POST: MembershipType/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Models.MembershipTypeModel membershipTypeModel = new Models.MembershipTypeModel();

                UpdateModel(membershipTypeModel);

                membershipTypeRepository.UpdateMembershiptype(membershipTypeModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditMembershipType");
            }
        }

        // GET: MembershipType/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.MembershipTypeModel membershipTypeModel = membershipTypeRepository.GetMembershipTypeByID(id);

            return View("DeleteMembershipType", membershipTypeModel);
        }

        // POST: MembershipType/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {

                membershipTypeRepository.DeleteMembershipType(id);

               

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeteleMembershipType");
            }
        }
    }
}

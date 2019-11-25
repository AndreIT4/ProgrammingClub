using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgrammingClubM.Controllers
{
    public class CodeSnippetController : Controller
    {
        private Repository.CodeSnippetRepository codeSnippetRepository = new Repository.CodeSnippetRepository();

        // GET: CodeSnippet
        public ActionResult Index()
        {
            List<Models.CodeSnippetModel> codeSnippets = codeSnippetRepository.GetAllCodeSnippets();

            return View("Index", codeSnippets);
        }

        // GET: CodeSnippet/Details/5
        public ActionResult Details(Guid id)
        {
            Models.CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetByID(id);

            return View("CodeSnippetDetails", codeSnippetModel);
        }

        // GET: CodeSnippet/Create
        public ActionResult Create()
        {
            return View("CreateCodeSnippet");
        }

        // POST: CodeSnippet/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.CodeSnippetModel codeSnippetModel = new Models.CodeSnippetModel();

                UpdateModel(codeSnippetModel);

                codeSnippetRepository.InsertCodeSnippet(codeSnippetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCodeSnippet");
            }
        }

        // GET: CodeSnippet/Edit/5
        public ActionResult Edit(Guid id)
        {
            Models.CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetByID(id);


            return View("EditCodeSnippet", codeSnippetModel);
        }

        // POST: CodeSnippet/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                Models.CodeSnippetModel codeSnippetModel = new Models.CodeSnippetModel();

                UpdateModel(codeSnippetModel);

                codeSnippetRepository.UpdateCodeSnippet(codeSnippetModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("EditCodeSnippet");
            }
        }

        // GET: CodeSnippet/Delete/5
        public ActionResult Delete(Guid id)
        {
            Models.CodeSnippetModel codeSnippetModel = codeSnippetRepository.GetCodeSnippetByID(id);

            return View("DeleteCodeSnippet", codeSnippetModel);
        }

        // POST: CodeSnippet/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                codeSnippetRepository.DeleteCodeSnippet(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteCodeSnippet");
            }
        }
    }
}

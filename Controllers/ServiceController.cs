using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerService.Models;

namespace ComputerService.Controllers
{

    public class ServiceController : Controller
    {
        #region variables

        private readonly Question _question;
        private readonly Questions _questions;

        #endregion

        public ServiceController()
        { 
            _questions = new Questions();
            _question = new Question(_questions.GetQuestions());
        }

        // GET: Service
        public ActionResult Index() => View();

        [HttpGet]
        public ActionResult GetQuestion()//Create Quest object with answer and Question
        {
            return View(_question);//return list of object
        }

        [HttpPost]
        public Question GetQuestion(Question listQuestion) =>
            listQuestion.SelectedAnswer.Count == _questions.GetNumberOfQuestions() ? listQuestion : null;
        
        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
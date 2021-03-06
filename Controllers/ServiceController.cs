using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerService.Models;
using System.Linq;
using System.Collections.Generic;
using Org.BouncyCastle.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace ComputerService.Controllers
{
    [Authorize]

    public class ServiceController : Controller
    {
        #region variables

        private readonly Question _question;
        private readonly Questions _questions;
        private readonly Logic _logic;
        private readonly Logic _resultlogic = new Logic();//create a list of all possible solutions

        #endregion

        public ServiceController()
        {
            _questions = new Questions();
            _question = new Question(_questions.GetQuestions());
            _logic = new Logic();
        }
        
        //Logic

        // GET: Service
       public ActionResult Index() => View();

        [HttpGet]
        public ActionResult GetQuestion()//Create Quest object with answer and Question
        {

            return View(_question);//return list of object
        }

        [HttpPost]
        public ActionResult GetQuestion(Question listQuestion)
        {
           

            if (listQuestion.SelectedAnswer.Count == _questions.GetNumberOfQuestions())
            {

                for (int i = 0; i < _questions.GetNumberOfQuestions(); i++)
                {
                    if (listQuestion.SelectedAnswer[i] == "2")
                    {

                        _resultlogic.Result.Add(_resultlogic.AllResult[i]);

                    }
                }
                if (listQuestion.SelectedAnswer.ToArray().SequenceEqual(_logic.Ar0))
                {
                    _resultlogic.Result.Add(_resultlogic.AllResult[7]);
                    return View("~/Views/Service/ResultView.cshtml", _resultlogic);
                }

                    return View("~/Views/Service/ResultView.cshtml", _resultlogic);
            }
            else
            {
                return View("~/Views/Service/ResultView.cshtml", _resultlogic);
            }
        }


        [HttpGet]
        public ActionResult ViewResult(LogicObj logic)
        {
            
            return View(logic);
        }
       


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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerService.Models;

namespace ComputerService.Controllers
{
    
    public class ServiceController : Controller
    {
        
        

        public Question Question = new Question();//Question obj
        [HttpPost]
        public ActionResult PutToArray(List<string> Answer)//putting to array ans and que
        {
           string[] Array =new string[10];
           //Array.Append(Answer);

            return Content(Array.ToString());
        }
        // GET: Service
        public ActionResult Index()
        {
           
            return View();
        }

        /* public ActionResult AddToArray0()
         {
             listQuestion.ListQust.Answer.Add("0");
             return View();
         }        
         public ActionResult AddToArray1()
         {
             listQuestion.ListQust.Answer.Add("1");
             return View();
         }*/

        [HttpGet]
        public  ActionResult  GetQuestion()//Create Quest object with answer and Question
        {

            Question listQuestion = new Question(){ ListQust = new Question(){ Que = new List<string>(), Answer = new List<string>()} };//create list of obj and instance of object in list


            listQuestion.ListQust.Que.Add("Does it turn off?");//type Question and default answer to 0
           listQuestion.ListQust.Answer.Add("0");

            listQuestion.ListQust.Que.Add( "Has it problem with web-connection?");
          listQuestion.ListQust.Answer.Add( "0");
            
            listQuestion.ListQust.Que.Add( "Has been bought  for more than 5 years?");
           listQuestion.ListQust.Answer.Add( "0"); 
            
            listQuestion.ListQust.Que.Add( "Does it frezee?");
          listQuestion.ListQust.Answer.Add( "0");   
            
            listQuestion.ListQust.Que.Add("Have it ever any mechanical accident?");
            listQuestion.ListQust.Answer.Add("0");

            listQuestion.ListQust.Que.Add( "Does it overheat?");
           listQuestion.ListQust.Answer.Add( "0");
            
            listQuestion.ListQust.Que.Add( "Is problem with devices detection?");
          listQuestion.ListQust.Answer.Add( "0"); 
                 

            return View(listQuestion);//return list of object

        }
        [HttpPost]
        public  Question  GetQuestion(Question listQuestion)
        {
            //foreach (var answer in listquestion.selectedanswer)
            //{
            //    if (bool.isnullorempty(answer))
            //    {
            //        // viewbag.message=
            //        return "you must mark all radiobutton";
            //    }
            //}

            //PutToArray(listQuestion.SelectedAnswer);
            return listQuestion;
            
        }

        public ActionResult SetQuestion(List<string> Answer)
        {
            PutToArray( Answer);
            return View();
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
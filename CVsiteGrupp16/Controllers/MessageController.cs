using Data.Contexts;
using Data.Models;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CVsiteGrupp16.Controllers
{
    public class MessageController : Controller
    {
        private MessageDbContext db = new MessageDbContext();

        // GET: Message
        public ActionResult Index()
        {
            var messages = db.messages.ToList();
            return View(messages);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        public ActionResult Create(string mottagare, int cvId)
        {
            var model = new MessageModel();
            model.UserName = mottagare;
            model.Id = cvId;
            return View(model);
        }


        

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Message existingMessage = db.messages.Find(id);
            if (existingMessage == null)
            {
                return HttpNotFound();
            }
            return View(existingMessage);
        }

        // POST: Message/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Message message = db.messages.Find(id);
                db.messages.Remove(message);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

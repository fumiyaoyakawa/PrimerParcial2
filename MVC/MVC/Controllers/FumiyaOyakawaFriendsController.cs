using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class FumiyaOyakawaFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: FumiyaOyakawaFriends
        public ActionResult Index()
        {
            return View(db.FumiyaOyakawaFriends.ToList());
        }

        // GET: FumiyaOyakawaFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            if (fumiyaOyakawaFriend == null)
            {
                return HttpNotFound();
            }
            return View(fumiyaOyakawaFriend);
        }

        // GET: FumiyaOyakawaFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FumiyaOyakawaFriends/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,Name,Amigo,Nickname,Birthdate")] FumiyaOyakawaFriend fumiyaOyakawaFriend)
        {
            if (ModelState.IsValid)
            {
                db.FumiyaOyakawaFriends.Add(fumiyaOyakawaFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fumiyaOyakawaFriend);
        }

        // GET: FumiyaOyakawaFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            if (fumiyaOyakawaFriend == null)
            {
                return HttpNotFound();
            }
            return View(fumiyaOyakawaFriend);
        }

        // POST: FumiyaOyakawaFriends/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,Name,Amigo,Nickname,Birthdate")] FumiyaOyakawaFriend fumiyaOyakawaFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fumiyaOyakawaFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fumiyaOyakawaFriend);
        }

        // GET: FumiyaOyakawaFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            if (fumiyaOyakawaFriend == null)
            {
                return HttpNotFound();
            }
            return View(fumiyaOyakawaFriend);
        }

        // POST: FumiyaOyakawaFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FumiyaOyakawaFriend fumiyaOyakawaFriend = db.FumiyaOyakawaFriends.Find(id);
            db.FumiyaOyakawaFriends.Remove(fumiyaOyakawaFriend);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

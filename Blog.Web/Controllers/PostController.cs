using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Core.DomainObjects;
using Blog.Core;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private EntitiesModel db = new EntitiesModel();

        // GET: /Post/
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Category).Include(p => p.User);
            return View(posts.ToList());
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO postdto = db.Posts.Find(id);
            if (postdto == null)
            {
                return HttpNotFound();
            }
            return View(postdto);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Url,ContentPreview,Content,CreatedDate,PublishDate,CategoryId,IsPublish,UserId")] PostDTO postdto)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(postdto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", postdto.UserId);
            return View(postdto);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO postdto = db.Posts.Find(id);
            if (postdto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", postdto.UserId);
            return View(postdto);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Url,ContentPreview,Content,CreatedDate,PublishDate,CategoryId,IsPublish,UserId")] PostDTO postdto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postdto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", postdto.UserId);
            return View(postdto);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO postdto = db.Posts.Find(id);
            if (postdto == null)
            {
                return HttpNotFound();
            }
            return View(postdto);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostDTO postdto = db.Posts.Find(id);
            db.Posts.Remove(postdto);
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

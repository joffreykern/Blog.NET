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
using Blog.Core.Repository;
using Blog.Infrastructure;
using Blog.Core.Infrastructure;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private EntitiesModel db = new EntitiesModel();
        private IRepository<PostDTO> _postRepository;
        private IRepository<UserDTO> _userRepository;
        private IRepository<CategoryDTO> _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostController(IRepository<PostDTO> postRepository, IRepository<UserDTO> userRepository, IRepository<CategoryDTO> categoryRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._userRepository = userRepository;
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        // GET: /Post/
        public ActionResult Index()
        {
            //var posts = db.Posts.Include(p => p.Category).Include(p => p.User);
            IEnumerable<PostDTO> posts = this._postRepository.GetAll();
            return View(posts.ToList());
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //PostDTO postdto = db.Posts.Find(id);
            PostDTO postdto = this._postRepository.First((int)id);
            if (postdto == null)
            {
                return HttpNotFound();
            }
            return View(postdto);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(this._categoryRepository.GetAll(), "Id", "Name");
            ViewBag.UserId = new SelectList(this._userRepository.GetAll(), "Id", "Username");
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
                //db.Posts.Add(postdto);
                //db.SaveChanges();
                this._postRepository.Add(postdto);
                this._unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this._categoryRepository.GetAll(), "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(this._userRepository.GetAll(), "Id", "Username", postdto.UserId);
            return View(postdto);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PostDTO postdto = db.Posts.Find(id);
            PostDTO postdto = this._postRepository.First((int)id);
            if (postdto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(this._categoryRepository.GetAll(), "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(this._userRepository.GetAll(), "Id", "Username", postdto.UserId);
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
                //db.Entry(postdto).State = EntityState.Modified;
                //db.SaveChanges();
                this._postRepository.Update(postdto);
                this._unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(this._categoryRepository.GetAll(), "Id", "Name", postdto.CategoryId);
            ViewBag.UserId = new SelectList(this._userRepository.GetAll(), "Id", "Username", postdto.UserId);
            return View(postdto);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PostDTO postdto = db.Posts.Find(id);
            PostDTO postdto = this._postRepository.First((int)id);
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
            //PostDTO postdto = db.Posts.Find(id);
            //db.Posts.Remove(postdto);
            //db.SaveChanges();
            this._postRepository.Delete(id);
            this._unitOfWork.SaveChanges();
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

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project_Entity;
using Project_UI.Areas.Admin.FilterAttributes;

namespace Project_UI.Areas.Admin.Controllers
{
    [CheckAuth]
    public class GlobalsController : BaseController
    {
        //29.10.2016 ne olduğunu çözemediğimizden bıraktık böylece
        

        // GET: Admin/Globals
        public ActionResult Index()
        {
            var globals = db.Globals.Include(g => g.AdDetail).Include(g => g.AdminUser);
            return View(globals.ToList());
        }

        // GET: Admin/Globals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Global global = db.Globals.Find(id);
            if (global == null)
            {
                return HttpNotFound();
            }
            return View(global);
        }

        // GET: Admin/Globals/Create
        public ActionResult Create()
        {
            ViewBag.AdDetailID = new SelectList(db.AdDetails, "ID", "Name");
            ViewBag.AdminUserID = new SelectList(db.AdminUsers, "ID", "Name");
            return View();
        }

        // POST: Admin/Globals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AdminUserID,AdDetailID,CreatedDate,UpdatedDate,DeletedDate,IsActive,IsDelete")] Global global)
        {
            if (ModelState.IsValid)
            {
                db.Globals.Add(global);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdDetailID = new SelectList(db.AdDetails, "ID", "Name", global.AdDetailID);
            ViewBag.AdminUserID = new SelectList(db.AdminUsers, "ID", "Name", global.AdminUserID);
            return View(global);
        }

        // GET: Admin/Globals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Global global = db.Globals.Find(id);
            if (global == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdDetailID = new SelectList(db.AdDetails, "ID", "Name", global.AdDetailID);
            ViewBag.AdminUserID = new SelectList(db.AdminUsers, "ID", "Name", global.AdminUserID);
            return View(global);
        }

        // POST: Admin/Globals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AdminUserID,AdDetailID,CreatedDate,UpdatedDate,DeletedDate,IsActive,IsDelete")] Global global)
        {
            if (ModelState.IsValid)
            {
                db.Entry(global).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdDetailID = new SelectList(db.AdDetails, "ID", "Name", global.AdDetailID);
            ViewBag.AdminUserID = new SelectList(db.AdminUsers, "ID", "Name", global.AdminUserID);
            return View(global);
        }

        // GET: Admin/Globals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Global global = db.Globals.Find(id);
            if (global == null)
            {
                return HttpNotFound();
            }
            return View(global);
        }

        // POST: Admin/Globals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Global global = db.Globals.Find(id);
            db.Globals.Remove(global);
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

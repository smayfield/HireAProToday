using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HireAProToday.Models;

namespace HireAProToday.Controllers
{
    // TODO: Add admin role restrictions.

    public class DirectoryCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DirectoryCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.DirectoryCategories.ToListAsync());
        }

        // GET: DirectoryCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = await db.DirectoryCategories.FindAsync(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DirectoryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] DirectoryCategory directoryCategory)
        {
            if (ModelState.IsValid)
            {
                db.DirectoryCategories.Add(directoryCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = await db.DirectoryCategories.FindAsync(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // POST: DirectoryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] DirectoryCategory directoryCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directoryCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(directoryCategory);
        }

        // GET: DirectoryCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DirectoryCategory directoryCategory = await db.DirectoryCategories.FindAsync(id);
            if (directoryCategory == null)
            {
                return HttpNotFound();
            }
            return View(directoryCategory);
        }

        // POST: DirectoryCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DirectoryCategory directoryCategory = await db.DirectoryCategories.FindAsync(id);
            db.DirectoryCategories.Remove(directoryCategory);
            await db.SaveChangesAsync();
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

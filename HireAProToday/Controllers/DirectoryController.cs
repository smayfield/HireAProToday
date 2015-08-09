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

    public class DirectoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Directory
        public async Task<ActionResult> Index(int? categoryId)
        {
            // filter by category if specified...
            List<Member> model;
            if (categoryId == null)
            {
                model = await db.Members.ToListAsync();
            }
            else
            {
                var category = db.DirectoryCategories.FirstOrDefault(c => c.Id == categoryId);
                if (category == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                model = await db.Members.Where(m => m.Categories.Contains(category)).ToListAsync();
            }

            return View(model);
        }

        // GET: Directory/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Directory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompanyName,FirstName,LastName,Address1,Address2,City,State,Zip,Phone,Fax,Cell,Email,DateJoined,Url,DuesPaid")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Directory/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Directory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanyName,FirstName,LastName,Address1,Address2,City,State,Zip,Phone,Fax,Cell,Email,DateJoined,Url,DuesPaid")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Directory/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Directory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Member member = await db.Members.FindAsync(id);
            db.Members.Remove(member);
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

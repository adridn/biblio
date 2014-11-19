using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblio;

namespace Biblio.Controllers
{
    public class Type_Auteur1Controller : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        // GET: Type_Auteur1
        public ActionResult Index()
        {
            return View(db.Type_Auteur.OrderBy(y => y.Nom).ToList());
        }

        // GET: Type_Auteur1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Auteur type_Auteur = db.Type_Auteur.Find(id);
            if (type_Auteur == null)
            {
                return HttpNotFound();
            }
            return View(type_Auteur);
        }

        // GET: Type_Auteur1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_Auteur1/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_TypeAuteur,Nom")] Type_Auteur type_Auteur)
        {
            if (ModelState.IsValid)
            {
                db.Type_Auteur.Add(type_Auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_Auteur);
        }

        // GET: Type_Auteur1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Auteur type_Auteur = db.Type_Auteur.Find(id);
            if (type_Auteur == null)
            {
                return HttpNotFound();
            }
            return View(type_Auteur);
        }

        // POST: Type_Auteur1/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_TypeAuteur,Nom")] Type_Auteur type_Auteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_Auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_Auteur);
        }

        // GET: Type_Auteur1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_Auteur type_Auteur = db.Type_Auteur.Find(id);
            if (type_Auteur == null)
            {
                return HttpNotFound();
            }
            return View(type_Auteur);
        }

        // POST: Type_Auteur1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_Auteur type_Auteur = db.Type_Auteur.Find(id);
            db.Type_Auteur.Remove(type_Auteur);
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

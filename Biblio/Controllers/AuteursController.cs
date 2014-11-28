using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblio;
using Biblio.ViewsModel;

namespace Biblio.Controllers
{
    //[Authorize]
    public class AuteursController : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        // GET: Auteurs
        public ActionResult Index()
        {
            return View(db.Auteur.OrderBy(y => y.Nom).ToList());
        }

        // GET: Auteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // GET: Auteurs/Create
        public ActionResult Create()
        {
            CreateAuteurViewModel typeAuteur = new CreateAuteurViewModel();
            typeAuteur.listTypeauteur = db.Type_Auteur.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_TypeAuteur.ToString() }).OrderBy(y => y.Text).ToList();
            return View(typeAuteur);
        }

        // POST: Auteurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CreateAuteurViewModel typeAuteur)
        {
            if (ModelState.IsValid)
            {
                Auteur auteur = new Auteur();
                auteur.Nom = typeAuteur.Nom;
                auteur.id_TypeAuteur = typeAuteur.id_TypeAuteur;
                db.Auteur.Add(auteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeAuteur);
        }

        // GET: Auteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            CreateAuteurViewModel typeAuteur = new CreateAuteurViewModel(auteur);
            typeAuteur.listTypeauteur = db.Type_Auteur.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_TypeAuteur.ToString() }).OrderBy(y => y.Text).ToList();
            

            return View(typeAuteur);
        }

        // POST: Auteurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CreateAuteurViewModel typeAuteur)
        {
            if (ModelState.IsValid)
            {
                Auteur auteur = new Auteur();
                auteur.id_Auteur = typeAuteur.id_Auteur;
                auteur.id_TypeAuteur = typeAuteur.id_TypeAuteur;
                auteur.Nom = typeAuteur.Nom;
                db.Entry(auteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeAuteur);
        }

        // GET: Auteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auteur auteur = db.Auteur.Find(id);
            if (auteur == null)
            {
                return HttpNotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auteur auteur = db.Auteur.Find(id);
            db.Auteur.Remove(auteur);
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

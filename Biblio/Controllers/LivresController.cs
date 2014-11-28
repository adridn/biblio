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
using Biblio.Extension;

namespace Biblio.Controllers
{
    //[Authorize]
    public class LivresController : Controller
    {
        private BiblioEntities db = new BiblioEntities();

        public ActionResult Search()
        {
            SearchViewModel svm = new SearchViewModel();
            svm.listCollection = db.Collections.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Collection.ToString() }).OrderBy(y => y.Text).ToList();

            svm.listLivre = new List<Livre>();          

            return View(svm);
        }


        [HttpPost]
        public ActionResult Search(SearchViewModel svm)
        {
            
                svm.listCollection = db.Collections.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Collection.ToString() }).ToList();

                if (string.IsNullOrEmpty(svm.Nom))
                    svm.listLivre = db.Livre.Where(x => x.id_Collection == svm.id_Collection).OrderBy(y=>y.Nom).ToList();
                else
                    svm.listLivre = db.Livre.Where(x => x.Nom.Contains(svm.Nom)).OrderBy(y => y.Nom).ToList();
           
            return View(svm);
        }

        
       

        // GET: Livres
        public ActionResult Index()
        {
            return View(db.Livre.OrderBy(y => y.id_Collection).ThenBy(z => z.Nom).ToList());
        }

        // GET: Livres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // GET: Livres/Create
        public ActionResult Create()
        {
            LivreViewModel lvm = new LivreViewModel();
            lvm.listAuteur = db.Auteur.Where(aut => aut.id_TypeAuteur == 2).Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Auteur.ToString() }).OrderBy(y => y.Text).ToList();
            lvm.listDessinateur = db.Auteur.Where(aut => aut.id_TypeAuteur == 1).Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Auteur.ToString() }).OrderBy(y => y.Text).ToList();
            lvm.listCollection = db.Collections.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Collection.ToString() }).OrderBy(y => y.Text).ToList();
            return View(lvm);
        }

        // POST: Livres/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivreViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                Livre livre=new Livre();
                livre.id_Auteur = lvm.id_Auteur;
                livre.id_Collection = lvm.id_Collection;
                livre.id_Dessinateur = lvm.id_Dessinateur;
                livre.Nom = lvm.Nom;
                //livre = (Livre)lvm;
                db.Livre.Add(livre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lvm);
        }

        // GET: Livres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            LivreViewModel lvm = new LivreViewModel(livre);
            lvm.listAuteur = db.Auteur.Where(aut => aut.id_TypeAuteur == 2).Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Auteur.ToString() }).OrderBy(y => y.Text).ToList();
            lvm.listDessinateur = db.Auteur.Where(aut => aut.id_TypeAuteur == 1).Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Auteur.ToString() }).OrderBy(y => y.Text).ToList();
            lvm.listCollection = db.Collections.Select(sl => new SelectListItem { Text = sl.Nom, Value = sl.id_Collection.ToString() }).OrderBy(y => y.Text).ToList();
            
            return View(lvm);
        }

        // POST: Livres/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( LivreViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                Livre livre = new Livre();
                livre.id_Livre = lvm.id_Livre;
                livre.id_Auteur = lvm.id_Auteur;
                livre.id_Collection = lvm.id_Collection;
                livre.id_Dessinateur = lvm.id_Dessinateur;
                livre.Nom = lvm.Nom;

                db.Entry(livre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lvm);
        }

        // GET: Livres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livre livre = db.Livre.Find(id);
            if (livre == null)
            {
                return HttpNotFound();
            }
            return View(livre);
        }

        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livre livre = db.Livre.Find(id);
            db.Livre.Remove(livre);
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

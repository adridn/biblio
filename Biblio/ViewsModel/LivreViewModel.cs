using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblio.ViewsModel
{
    public class LivreViewModel:Livre
    {
        public List<SelectListItem> listAuteur { get; set; }
        public List<SelectListItem> listCollection { get; set; }
        public List<SelectListItem> listDessinateur { get; set; }


        public LivreViewModel()
        {

        }

        public LivreViewModel(Livre livre)
        {
            this.Nom = livre.Nom;
            this.id_Auteur = livre.id_Auteur;
            this.id_Collection = livre.id_Collection;
            this.id_Dessinateur = livre.id_Dessinateur;
            this.id_Livre=livre.id_Livre;

        }

    }

}
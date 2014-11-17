using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblio.ViewsModel
{
    public class CreateAuteurViewModel:Auteur
    {
        public List<SelectListItem> listTypeauteur { get; set; }

        public CreateAuteurViewModel()
        {
        
        }
        public CreateAuteurViewModel(Auteur auteur)
        {
            this.id_Auteur = auteur.id_Auteur;
            this.id_TypeAuteur = auteur.id_TypeAuteur;
            this.Nom = auteur.Nom;
        }
    }
}
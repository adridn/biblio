//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auteur
    {
        public Auteur()
        {
            this.Livre = new HashSet<Livre>();
            this.Livre1 = new HashSet<Livre>();
        }
    
        public int id_Auteur { get; set; }
        public string Nom { get; set; }
        public Nullable<int> id_TypeAuteur { get; set; }
    
        public virtual Type_Auteur Type_Auteur { get; set; }
        public virtual ICollection<Livre> Livre { get; set; }
        public virtual ICollection<Livre> Livre1 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace atelier5.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Shipper_ID { get; set; }
        public string Company_Name { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}

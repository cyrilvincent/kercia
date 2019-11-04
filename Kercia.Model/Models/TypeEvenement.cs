using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class TypeEvenement
    {
        public TypeEvenement()
        {
            Evenement = new HashSet<Evenement>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public bool EstAction { get; set; }

        public virtual ICollection<Evenement> Evenement { get; set; }
    }
}

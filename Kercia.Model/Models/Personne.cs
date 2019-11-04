using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class Personne
    {
        public Personne()
        {
            Evenements = new HashSet<Evenement>();
            SessionPersonnes = new HashSet<SessionPersonnes>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public int Type { get; set; }

        public virtual ICollection<Evenement> Evenements { get; set; }
        
    }
}

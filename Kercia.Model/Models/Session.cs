using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class Session
    {
        public Session()
        {
            Evenement = new HashSet<Evenement>();
            SessionPersonnes = new HashSet<SessionPersonnes>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Etat { get; set; }
        public string ActionARealiser { get; set; }
        public string Url { get; set; }

        public virtual Planning Planning { get; set; }
        public virtual ICollection<Evenement> Evenement { get; set; }
        public virtual ICollection<SessionPersonnes> SessionPersonnes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class Evenement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Resume { get; set; }
        public string Contenu { get; set; }
        public bool EstLu { get; set; }
        public bool EstTraite { get; set; }
        public int? PersonneId { get; set; }
        public int? SessionId { get; set; }
        public int? TypeEvenementId { get; set; }

        public virtual Personne Personne { get; set; }
        public virtual Session Session { get; set; }
        public virtual TypeEvenement TypeEvenement { get; set; }
    }
}

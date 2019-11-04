using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class SessionPersonnes
    {
        public int SessionId { get; set; }
        public int PersonneId { get; set; }

        public virtual Personne Personne { get; set; }
        public virtual Session Session { get; set; }
    }
}

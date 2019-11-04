using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class Planning
    {
        public Planning()
        {
            PlanningDate = new HashSet<PlanningDate>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public virtual Session IdNavigation { get; set; }
        public virtual ICollection<PlanningDate> PlanningDate { get; set; }
    }
}

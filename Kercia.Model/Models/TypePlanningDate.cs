using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class TypePlanningDate
    {
        public TypePlanningDate()
        {
            PlanningDate = new HashSet<PlanningDate>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }
        public int ValeurAjouteeParDefaut { get; set; }

        public virtual ICollection<PlanningDate> PlanningDate { get; set; }
    }
}

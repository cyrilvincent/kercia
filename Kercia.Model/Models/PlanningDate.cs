using System;
using System.Collections.Generic;

namespace Kercia.Model.Models
{
    public partial class PlanningDate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? PlanningId { get; set; }
        public int? TypePlanningDateId { get; set; }

        public virtual Planning Planning { get; set; }
        public virtual TypePlanningDate TypePlanningDate { get; set; }
    }
}

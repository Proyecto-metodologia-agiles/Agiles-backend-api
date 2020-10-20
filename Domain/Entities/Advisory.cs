using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{
    public class Advisory : Entity<int>
    {
        public Proyecto Proyect { get; set; }
        public Asesor Thematic_Advisor { get; set; }
        public Asesor Metodologic_Advisor { get; set; }
        public int AssignedHours { get; set; }
        public String semester { get; set; }
        public String Year { get; set; }

        public Advisory()
        {
            this.AssignedHours = 0;
        }

        public int Build_advisory(Advisory advisory)
        {
            if (advisory.Proyect==null || advisory.semester==null || advisory.Thematic_Advisor==null || advisory.Year==null || advisory.Metodologic_Advisor==null || advisory.AssignedHours==0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}

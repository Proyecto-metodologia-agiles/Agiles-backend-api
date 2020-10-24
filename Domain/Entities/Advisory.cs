using Domain.Base;
using System;

namespace Domain.Entities
{
    public class Advisory : Entity<int>
    {
        public Proyecto Proyect { get; set; }
        public Asesor ThematicAdvisor { get; set; }
        public Asesor MetodologicAdvisor { get; set; }
        public int AssignedHours { get; set; }
        public String semester { get; set; }
        public String Year { get; set; }

        public Advisory()
        {
            this.AssignedHours = 0;
        }

        public int Verify_advisory(Advisory advisory)
        {
            if (advisory.Proyect == null || advisory.semester == null || advisory.ThematicAdvisor == null || advisory.Year == null || advisory.MetodologicAdvisor == null || advisory.AssignedHours == 0)
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

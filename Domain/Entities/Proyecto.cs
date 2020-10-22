using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{

    public class Proyecto: Entity<int>
    {
		public string Title { get; set; }
		public string Url_Archive { get; set; }
		public string Focus { get; set; }
		public int Cut { get; set; }
		public string Line { get; set; }
		public DateTime Date { get; set; }
		public Asesor Thematic_Advisor { get; set; }
		public Asesor Metodologic_Advisor { get; set; }
		public Estudiante Student_1 { get; set; }
		public Estudiante Student_2 { get; set; }


		public Proyecto()
        {
			this.Cut = 0;
        }


		public Proyecto(string title, string url, string focus, int cut, string line, DateTime date, Asesor Thematic_Advisor, Asesor metodologic_advisor)
		{
			this.Title = title;
			this.Url_Archive = url;
			this.Focus = focus;
			this.Cut = cut;
			this.Line = line;
			this.Date = date;
			this.Thematic_Advisor = Thematic_Advisor;
			this.Metodologic_Advisor = metodologic_advisor;
			
		}

		public string Verify_proyecto(Proyecto proyecto)
		{
			if (proyecto.Title == null || proyecto.Url_Archive == null || proyecto.Focus == null || proyecto.Cut == 0 || proyecto.Line == null || proyecto.Date == null || proyecto.Thematic_Advisor == null || proyecto.Metodologic_Advisor == null || proyecto.Student_1==null)
			{
				return "Digite los campos primordiales para el registro";
			}
			else
			{
				return "Proyecto registrado correctamente";
			}
		}




	}
}

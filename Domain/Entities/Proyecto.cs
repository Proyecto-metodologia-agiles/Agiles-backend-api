using System;
using System.Collections.Generic;
using System.Text;
using Domain.Base;

namespace Domain.Entities
{

    public class Proyecto: Entity<int>
    {
		public string Nombre;
		public string Url_Archivo;
		public string Enfoque;
		public int Corte;
		public string Linea;
		public DateTime Fecha;
		public Asesor Asesor_tematico;
		public Asesor Asesor_metodologico;

		public Proyecto(string Nombre, string Url_Archivo, string Enfoque, int Corte, string Linea, DateTime Fecha, Asesor Asesor_tematico, Asesor Asesor_metodologico)
		{
			this.Nombre = Nombre;
			this.Url_Archivo = Url_Archivo;
			this.Enfoque = Enfoque;
			this.Corte = Corte;
			this.Linea = Linea;
			this.Fecha = Fecha;
			this.Asesor_tematico = Asesor_tematico;
			this.Asesor_metodologico = Asesor_metodologico;
			
		}

		public string Validar_proyecto(Proyecto proyecto)
		{
			if (proyecto.Nombre == null || proyecto.Url_Archivo == null || proyecto.Enfoque == null || proyecto.Corte == null || proyecto.Linea == null || proyecto.Fecha == null || proyecto.Asesor_metodologico == null || proyecto.Asesor_tematico ==null)
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

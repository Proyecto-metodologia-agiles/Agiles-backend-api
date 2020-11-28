using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mailers
{

    public class Plantilla
    {
        public string NombreCompleto { set; get; }

        public string TituloProyecto { set; get; }

        public string Horas { set; get; }

        public string Correo { set; get; }

        public string Celular { set; get; }

    }

    public static class Theme
    {
        public static string Plantilla(Plantilla plantillas, int type = 1)
        {

            string contenido = "";
            switch (type)
            {
                case 1:
                    {
                        //CreateAdvisoryService
                        contenido = "<html>Cordial saludo  " + plantillas.NombreCompleto + "," + "<br><br>"
                       + " Se le informa que se le ha asignado la siguiente asesoria:" + "<br><br>"
                       + " Proyecto:  " + plantillas.TituloProyecto + " " + "<br><br>"
                       + " Horas de asesoria a la semana:  " + plantillas.Horas + " " + "<br><br>"
                       + " De antemano agradecemos la confianza depositada en nosotros" + "<br><br>"
                       + " Atentamente:" + "<br>" + "<br>"
                       + " Universidad Popular del Cesar." + "<br>"
                       + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";
                        break;
                        
                    }
                case 2:
                    {
                        //CreateEvaluationService
                         contenido = "<html>Cordial saludo  " + plantillas.NombreCompleto + "," + "<br><br>"
                        + " Se le informa que su proyecto con titulo:" + "<br><br>"
                        + " Proyecto:  " + plantillas.TituloProyecto + " " + "<br><br>"
                        + " Ha sido valorado por el comite, por favor revise el estado de su proyecto<br><br> " 
                        + " De antemano agradecemos la confianza depositada en nosotros" + "<br><br>"
                        + " Atentamente:" + "<br>" + "<br>"
                        + " Universidad Popular del Cesar." + "<br>"
                        + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";
                        break;

                    }
                case 3:
                    {
                        //3. CreateValoracionService
                        contenido = "<html>Cordial saludo  " + plantillas.NombreCompleto + "," + "<br><br>"
                        + " Se le informa que su proyecto con titulo:" + "<br><br>"
                        + " Proyecto:  " + plantillas.TituloProyecto + " " + "<br><br>"
                        + " Ha sido evaluado y se le han hecho algunas obervaciones, por favor revise las observaciones realizadas  a su proyecto y corrija el documento"+"<br ><br>" 
                        + " De antemano agradecemos la confianza depositada en nosotros" + "<br><br>"
                        + " Atentamente:" + "<br>" + "<br>"
                        + " Universidad Popular del Cesar." + "<br>"
                        + " Correo: 1234@unicesar.edu.co - Celular (Whatsapp): 3042065930" + "<br><br></html>";
                        break;
                    }
            }

            
            return contenido;
        }
    }
}

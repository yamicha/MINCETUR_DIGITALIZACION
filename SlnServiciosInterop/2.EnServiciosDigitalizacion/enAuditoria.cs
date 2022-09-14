using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EnServiciosDigitalizacion
{
   public class enAuditoria
    {
        public object Objeto { get; set; }
        public string MensajeSalida { get; set; }
        public int Code { get; set; }
        public string ErrorLog { get; set; }
        public bool EjecucionProceso { get; set; }
        public string URL { get; set; }

        public bool Rechazo { get; set; } // Auxiliar

        public void NoAutorizado(string URL_)
        {
            Objeto = null;
            URL = URL_;
            MensajeSalida = "";
            ErrorLog = "";
            Rechazo = false;
            EjecucionProceso = true;
        }

        public void Limpiar()
        {
            Objeto = null;
            MensajeSalida = "";
            ErrorLog = "";
            Rechazo = false;
            EjecucionProceso = true;
            Code = (int)HttpStatusCode.OK; 
        }

        public void Rechazar(String mensaje)
        {
            Code = (int)HttpStatusCode.NotFound;
            Objeto = null;
            MensajeSalida = mensaje;
            ErrorLog = mensaje;
            Rechazo = true;
            EjecucionProceso = true;
        }

        public void Error(Exception ex)
        {
            Objeto = null;
            MensajeSalida = ex.Message;
            Code = (int)HttpStatusCode.InternalServerError;
            ErrorLog = ex.ToString();
            Rechazo = true;
            EjecucionProceso = false;
        }
    }
}

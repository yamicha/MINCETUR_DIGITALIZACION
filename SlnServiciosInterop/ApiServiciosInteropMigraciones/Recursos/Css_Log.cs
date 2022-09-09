﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
namespace ApiServiciosMicroformas.Recursos
{
    public class Css_Log
    {
        public static string Guardar(string texto)
        {
            string CODIGO_LOG = string.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Year, DateTime.Now.Hour.ToString().PadLeft(2, '0'), DateTime.Now.Minute.ToString().PadLeft(2, '0'), DateTime.Now.Second.ToString().PadLeft(2, '0'), DateTime.Now.Millisecond.ToString().PadLeft(2, '0'));

            string Milog = AppDomain.CurrentDomain.BaseDirectory + "Recursos/Log/" + CODIGO_LOG + "Log.txt";
            File.Create(Milog).Close();
            TextWriter tw = new StreamWriter(Milog);
            tw.WriteLine(texto);
            tw.Close();
            return CODIGO_LOG;
        }

        public static string Mensaje(string CODIGO_LOG)
        {
            string Mensaje_salida = "\r\n" + "\r\n" + ConfigurationManager.AppSettings["Mensaje_Log"].ToString() + ", su código de error es :" + CODIGO_LOG;
            return Mensaje_salida;
        }

        public static string Mensaje2()
        {
            string Mensaje_salida = "\r\n" + "\r\n" + ConfigurationManager.AppSettings["Mensaje_Log"].ToString();
            return Mensaje_salida;
        }

    }
}

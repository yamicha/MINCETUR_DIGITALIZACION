using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral;
using Frotend.ArchivoCentral.Micetur.Recursos;
using Newtonsoft.Json;
using ServiceReference1;
using Utilitarios.Helpers.Authorization;

namespace Frotend.ArchivoCentral.Micetur.Helpers
{
    public class CssUtil
    {

        public async Task<string> ClientEncriptarIdLaser(long ID_LASER, int cod_usuario)
        {
            using (WCFSeguridadEncripDesencripClient client = new WCFSeguridadEncripDesencripClient())
            {
                string llave = await client.traeLlaveAsync();
                string ID_LASERX = ID_LASER + "|" + AppSettings.AppId;
                string COD_ENCRIPTADO = string.Format("{0}{1}{2}", HttpUtility.UrlEncode(await client.encriptarAESAsync(ID_LASERX, llave)), "&Cod=",
                    HttpUtility.UrlEncode(await client.encriptarAESAsync(cod_usuario.ToString(), llave)));
                return COD_ENCRIPTADO;
            }
        }
        /// <summary>
        /// estructura los modulos del usuario
        /// </summary>
        /// <param name="ListModulos">Lista de modulos</param>
        /// <returns>menu estruturado en formato string</returns>
        public string traeListaOpcionesMenu(List<enModulos> ListModulos)
        {
            string html = string.Empty;
            try
            {
                html += "<div class='navigation-toggler'>";
                html += "<i class='clip-chevron-left' style='font-weight:bold'></i>";
                html += "<i class='clip-chevron-right' style='font-weight:bold'></i>";
                html += "</div>";
                if ((ListModulos != null) && (ListModulos.Count > 0))
                {
                    GenerarLista(ListModulos, ref html, 1);
                }
                return html;
            }
            catch (Exception ex)
            {
                Log.Guardar(ex.Message.ToString());
                return html = string.Empty;
            }
        }
        internal void GenerarLista(List<enModulos> items, ref string menu, int nivel)
        {
            string cssUL = string.Empty;
            string cssLI = string.Empty;
            string vlInvocar = "javascript:void(0)";
            if (nivel == 1)
            {
                cssUL = "main-navigation-menu";
            }
            else
            {
                cssUL = "sub-menu";
            }
            if (nivel == 1)
            {
                //string dashboard = " <li  id='liModSecretarial' class='active' ><a id='aModuloSecretarial' href='javascript:" + vlInvocar + ";'><i class='clip-users-2'></i><span class='title'> Gestión de la Digitalización </span><span'class='selected'></span></a></li>";
                menu = menu + "<ul  class='" + cssUL + "'>"  + Convert.ToChar(13);
            }
            else
            {
                menu = menu + "<ul  class='" + cssUL + "' >" + Convert.ToChar(13);
            }
            foreach (enModulos item in items)
            {
                bool existe = true;
                string ls_style_li = "";
                if ((existe == true))
                {
                    if (item.ID_OPCION.Length == 2) ls_style_li = "background-color:white";
                    menu += "<li class='" + cssLI + "' id='" + item.DES_URLLABEL + "' style='" + ls_style_li + "' > ";
                    if (item.NUM_NIVEL == 1 && item.ID_OPCION.Length == 2)
                    {

                        menu += "<a href='javascript:void(0);'>";
                        menu += "<i class='" + item.DES_URLIMAGEN + "'></i>";
                        menu += "<span   class='title'> " + item.DES_OPCION + "</span><i class='icon-arrow'></i><span  class='selected'></span>";
                        menu += "</a>"; nivel++;
                    }
                    else
                    {
                        if (item.ID_OPCION.Length == 2)
                        {
                            menu += "<a  href='"+ item.DES_URL + "'  />" + item.DES_OPCION + "</a>";
                        }
                    }
                    //string df = items.Find(x => x.ID_OPCION.Contains("seat"));
                    int cuenta = 0;
                    foreach (enModulos itemB in items)
                    {
                        int carc = itemB.ID_OPCION.Length;
                        if (carc > 2)
                        {
                            if (itemB.ID_OPCION.Substring(0, carc - 2) == item.ID_OPCION)
                            {
                                cuenta++;
                            }
                        }
                    }
                    if (cuenta != 0)
                    {
                        string ID_OPCION = item.ID_OPCION;
                        llenarhijos(items, ref menu, ID_OPCION);
                    }
                    else
                    {
                        //items.Remove(item);
                    }
                    menu += "</li>" + Convert.ToChar(13);
                }

            }
            menu += "</ul>" + Convert.ToChar(13);
        }
        internal void llenarhijos(List<enModulos> items, ref string menu, string ID_OPCION)
        {
            string cssUL = string.Empty;
            string cssLI = string.Empty;
            string vlInvocar = "javascript:void(0)";
            //string vlInvocar = "InvocaReporte()";

            cssUL = "sub-menu";
            menu = menu + "<ul  class='" + cssUL + "' >" + Convert.ToChar(13);

            foreach (enModulos item in items)
            {
                int carc = item.ID_OPCION.Length;
                string ls_style_li = "";
                if (carc > 2)
                {
                    if (item.ID_OPCION.Substring(0, carc - 2) == ID_OPCION)
                    {
                        menu += "<li class='" + cssLI + "' id='" + item.DES_URLLABEL + "' style='" + ls_style_li + "' > ";
                        menu += "<a  href='/"+ item.DES_URL + "'/>" + item.DES_OPCION + "</a>";
                        int cuenta = 0;
                        foreach (enModulos itemB in items)
                        {
                            int carc1 = itemB.ID_OPCION.Length;
                            if (carc1 > 2)
                            {
                                if (itemB.ID_OPCION.Substring(0, carc - 2) == item.ID_OPCION)
                                {
                                    cuenta++;
                                }
                            }
                        }
                        if (cuenta != 0)
                        {
                            string ID_OPCION1 = item.ID_OPCION;
                            llenarhijos(items, ref menu, ID_OPCION1);
                        }
                        else
                        {
                            // items.Remove(item);
                        }
                        menu += "</li>" + Convert.ToChar(13);
                    }
                }
            }
            menu += "</ul>" + Convert.ToChar(13);
        }


    }
}

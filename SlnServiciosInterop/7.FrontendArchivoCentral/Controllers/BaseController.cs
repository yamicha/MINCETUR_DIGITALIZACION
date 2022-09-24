using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Helpers.Authorization; 

namespace Frotend.ArchivoCentral.Micetur.Controllers
{
    public class BaseController : Controller
    {
        // GET: BaseController
        public BaseController() {
            ValidarSeccion(); 
        }
        UserLogin AdministraSession()
        {
            UserLogin session = null;
            //var Id_Personal = this.User.Claims.FirstOrDefault(c => c.Type == "Id_Personal")?.Value;
            //var usuario_nombre = this.User.Claims.FirstOrDefault(c => c.Type == "Nombre")?.Value;
            //var menu = this.User.Claims.FirstOrDefault(c => c.Type == "Menu")?.Value;
            //var autenticacion = this.User.Claims.FirstOrDefault(c => c.Type == "Autenticacion")?.Value;
            //var login = this.User.Claims.FirstOrDefault(c => c.Type == "Login")?.Value;
            //session = new UserLogin
            //{
            //    IdUsuario = (int)Id_Personal,
            //    //ID_PERSONAL = Id_Personal,
            //    //Nombre = usuario_nombre,
            //    //Autenticacion = autenticacion
            //};
            return session;
        }

        public void ValidarSeccion() {

            UserLogin session = new UserLogin(); 
            ViewBag.id_perfil = 2;
            ViewBag.idUsuario = 25;
            ViewBag.cod_usuario = "iperez";
            ViewBag.UserName = "Ivan Perez Tinataya";
            ViewBag.Desc_Oficina = "MI CASA"; 
        }



    }
}

using System;
using System.Web; 
using System.Threading.Tasks;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral;
using Utilitarios.Helpers;
using ApiServiciosDigitalizacion.Recursos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Carga
{
    [EnableCors("ReglasCors")]
    [Route("api/archivo-central/carga")]
    public class CargaController : ControllerBase
    {
        [HttpPost]
        [Route("subir-excel")]
        public ActionResult CargarArchivo(IFormFile fileArchivo, FormCollection forms)
        {

            return null; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServiciosDigitalizacion.resource.ArchivoCentral;
using EnServiciosDigitalizacion.ArchivoCentral;
using EnServiciosDigitalizacion;
using ApiServiciosDigitalizacion.Recursos;
using System.Net;
using System.Net.Http;
using Utilitarios.Recursos;
using Microsoft.AspNetCore.Cors;

namespace ApiServiciosDigitalizacion.Controllers
{
    [EnableCors("AccesoCors")]
    [Route("api/archivo-central/")]
    public class BaseApiController : ControllerBase
    {


        [HttpGet]
        [Route("get-file/{IdDocumento}")]
        public IActionResult Get_file(string idDocumento)
        {
            enAuditoria auditoria = new enAuditoria();
            try
            {
                byte[] ByteFile = null;
                string RUTA_ARCHIVO_TEMPORAL = Rutas.Ruta_Temporal() + idDocumento; 
                ByteFile = System.IO.File.ReadAllBytes(RUTA_ARCHIVO_TEMPORAL);
                if (System.IO.File.Exists(RUTA_ARCHIVO_TEMPORAL))
                    System.IO.File.Delete(RUTA_ARCHIVO_TEMPORAL);
                return File(ByteFile, "application/vnd.ms-excel", "Documentos"+DateTime.Now+".xlsx");

            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                string CodigoLog = Log.Guardar(auditoria.ErrorLog);
                auditoria.MensajeSalida = Log.Mensaje(CodigoLog);
            }
            return StatusCode(auditoria.Code, auditoria);
        }


    }
}

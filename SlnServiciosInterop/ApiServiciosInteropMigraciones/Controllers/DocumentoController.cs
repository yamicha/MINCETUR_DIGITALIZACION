using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServiciosMicroformas.Controllers
{
    [Route("api/[controller]")]
    public class DocumentoController : ControllerBase
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;

        public DocumentoController(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
        }


        // GET api/<DocumentoController>/
        [HttpGet]
        [Route("[action]/{strUsuario}/key/{strKey}/numDocumento/{strNumDocumento}")]
        public Models.ResultadoMigraModel consultar(string strUsuario, string strKey, string strNumDocumento) =>
            new resource.clases.Repositorio(this._ConfigurationManager).consultarDocumento(
                new Models.DatosMigraModel()
                {
                    CredencialModel = new Models.CredencialModel()
                    {
                        Usuario = strUsuario,
                        Pin = strKey
                    },
                    SolicitudModel = new Models.SolicitudModel() { NumDocumento = strNumDocumento }
                });
    }
}

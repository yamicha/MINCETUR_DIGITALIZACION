using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using NeServiciosDigitalizacion.Seguridad;
using Utilitarios.Helpers.Authorization;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.Seguridad
{
    public class DominioRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private NeServiciosDigitalizacion.Seguridad.neDominio _rule = null;

        public DominioRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new NeServiciosDigitalizacion.Seguridad.neDominio(_objCoConexionDb);
        }

        public List<enDominio> Dominio_Listar(enDominio entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Dominio_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enDominio>();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

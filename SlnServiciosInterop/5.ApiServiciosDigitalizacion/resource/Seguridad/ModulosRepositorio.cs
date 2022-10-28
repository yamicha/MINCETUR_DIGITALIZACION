using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using NeServiciosDigitalizacion.Seguridad;
using Utilitarios.Helpers.Authorization; 
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.Seguridad
{
    public class ModulosRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private NeServiciosDigitalizacion.Seguridad.enModulos _rule = null;

        public ModulosRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new NeServiciosDigitalizacion.Seguridad.enModulos(_objCoConexionDb);
        }

        public List<Utilitarios.Helpers.Authorization.enModulos> Modulos_Listar(Utilitarios.Helpers.Authorization.enModulos entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Modulos_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<Utilitarios.Helpers.Authorization.enModulos>();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

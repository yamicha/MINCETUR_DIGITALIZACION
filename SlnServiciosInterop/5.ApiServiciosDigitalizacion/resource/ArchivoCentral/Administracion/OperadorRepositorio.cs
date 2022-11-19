using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class OperadorRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neOperador _rule = null;

        public OperadorRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neOperador(_objCoConexionDb);
        }

        public List<enOperador> Operador_Listar(enOperador entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Operador_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enOperador>();
            }
        }

        public void Operador_Insertar(enOperador objenOperador, ref enAuditoria auditoria)
        {
            _rule.Operador_Insertar(objenOperador, ref auditoria);
        }

        public void Operador_Estado(enOperador objenOperador, ref enAuditoria auditoria)
        {
            _rule.Operador_Estado(objenOperador, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

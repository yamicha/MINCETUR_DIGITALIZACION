using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class FondoRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neFondo _rule = null;

        public FondoRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neFondo(_objCoConexionDb);
        }

        public List<enFondo> Fondo_Listar(enFondo entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Fondo_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enFondo>();
            }
        }
        public enFondo Fondo_ListarUno(enFondo entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Fondo_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enFondo();
            }
        }

        public void Fondo_Insertar(enFondo objenFondo, ref enAuditoria auditoria)
        {
            _rule.Fondo_Insertar(objenFondo, ref auditoria);
        }
        public void Fondo_Actualizar(enFondo objenFondo, ref enAuditoria auditoria)
        {
            _rule.Fondo_Actualizar(objenFondo, ref auditoria);
        }
        public void Fondo_Estado(enFondo objenFondo, ref enAuditoria auditoria)
        {
            _rule.Fondo_Estado(objenFondo, ref auditoria);
        }
        public void Fondo_Eliminar(enFondo objenFondo, ref enAuditoria auditoria)
        {
            _rule.Fondo_Eliminar(objenFondo, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

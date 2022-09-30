using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class SoporteRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neSoporte _rule = null;

        public SoporteRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neSoporte(_objCoConexionDb);
        }

        public List<enSoporte> Soporte_Listar(enSoporte entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Soporte_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enSoporte>();
            }
        }
        public enSoporte Soporte_ListarUno(enSoporte entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Soporte_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enSoporte();
            }
        }

        public void Soporte_Insertar(enSoporte objenSoporte, ref enAuditoria auditoria)
        {
            _rule.Soporte_Insertar(objenSoporte, ref auditoria);
        }
        public void Soporte_Actualizar(enSoporte objenSoporte, ref enAuditoria auditoria)
        {
            _rule.Soporte_Actualizar(objenSoporte, ref auditoria);
        }
        public void Soporte_Estado(enSoporte objenSoporte, ref enAuditoria auditoria)
        {
            _rule.Soporte_Estado(objenSoporte, ref auditoria);
        }
        public void Soporte_Eliminar(enSoporte objenSoporte, ref enAuditoria auditoria)
        {
            _rule.Soporte_Eliminar(objenSoporte, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

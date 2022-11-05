using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using NeServiciosDigitalizacion.Ventanilla.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.Ventanilla.Administracion
{
    public class ObservacionRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neObservacion _rule = null;

        public ObservacionRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neObservacion(_objCoConexionDb);
        }

        public List<enObservacion> Observacion_Listar(enObservacion entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Observacion_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enObservacion>();
            }
        }
        public enObservacion Observacion_ListarUno(enObservacion entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Observacion_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enObservacion();
            }
        }

        public void Observacion_Insertar(enObservacion objenObservacion, ref enAuditoria auditoria)
        {
            _rule.Observacion_Insertar(objenObservacion, ref auditoria);
        }
        public void Observacion_Actualizar(enObservacion objenObservacion, ref enAuditoria auditoria)
        {
            _rule.Observacion_Actualizar(objenObservacion, ref auditoria);
        }
        public void Observacion_Estado(enObservacion objenObservacion, ref enAuditoria auditoria)
        {
            _rule.Observacion_Estado(objenObservacion, ref auditoria);
        }
        public void Observacion_Eliminar(enObservacion objenObservacion, ref enAuditoria auditoria)
        {
            _rule.Observacion_Eliminar(objenObservacion, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

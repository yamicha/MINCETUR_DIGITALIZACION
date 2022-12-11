using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion;
using System;
using System.Collections.Generic;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class AreaRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neArea _rule = null;

        public AreaRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neArea(_objCoConexionDb);
        }

        public List<enArea> Area_Listar(enArea entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Area_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enArea>();
            }
        }

        public enArea Area_ListarUno(enArea entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Area_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enArea();
            }
        }

        public void Area_Insertar(enArea objenArea, ref enAuditoria auditoria)
        {
            _rule.Area_Insertar(objenArea, ref auditoria);
        }
        public void Area_Actualizar(enArea objenArea, ref enAuditoria auditoria)
        {
            _rule.Area_Actualizar(objenArea, ref auditoria);
        }
        public void Area_Estado(enArea objenArea, ref enAuditoria auditoria)
        {
            _rule.Area_Estado(objenArea, ref auditoria);
        }
        public void Area_Eliminar(enArea objenArea, ref enAuditoria auditoria)
        {
            _rule.Area_Eliminar(objenArea, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

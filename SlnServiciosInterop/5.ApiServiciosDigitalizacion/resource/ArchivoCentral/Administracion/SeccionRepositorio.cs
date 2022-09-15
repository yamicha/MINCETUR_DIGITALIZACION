using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion; 
using EnServiciosDigitalizacion;
using NeServiciosDigitalizacion.ArchivoCentral.Administracion; 
using CoServiciosDigitalizacion;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Administracion
{
    public class SeccionRepositorio : IDisposable
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private  coConexionDb _objCoConexionDb;
        private neControlCarga _rule = null; 

        public SeccionRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neSeccion(_objCoConexionDb);
        }

        public List<enSeccion> Seccion_Listar(enSeccion entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Seccion_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enSeccion>();
            }
        }
        public enSeccion Seccion_ListarUno(enSeccion entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Seccion_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enSeccion();
            }
        }

        public void Seccion_Insertar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            _rule.Seccion_Insertar(objEnSeccion, ref auditoria);
        }
        public void Seccion_Actualizar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            _rule.Seccion_Actualizar(objEnSeccion, ref auditoria);
        }
        public void Seccion_Estado(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            _rule.Seccion_Estado(objEnSeccion, ref auditoria);
        }
        public void Seccion_Eliminar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            _rule.Seccion_Eliminar(objEnSeccion, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

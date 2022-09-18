using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using NeServiciosDigitalizacion.ArchivoCentral.Carga; 
namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Carga
{
    public class CargaRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private enCarga _rule = null;
        public CargaRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new enCarga(_objCoConexionDb);
        }
        public enTabla Carga_TablaListarUno(enTabla objtabla, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Carga_TablaListarUno(objtabla, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enTabla();
            }
        }
        public List<enCampo> Carga_CamposListar(enCampo objcampo, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Carga_CamposListar(objcampo, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enCampo>();
            }
        }
        public void Registrar_Carga(string COD_TABLA_TEMPORAL, DataTable dt, string[] col, ref enAuditoria auditoria)
        {
            _rule.Registrar_Carga(COD_TABLA_TEMPORAL, dt, col, ref auditoria);
        }
        public void Carga_ControlCargaInsertar(enControlCarga entidad, ref enAuditoria auditoria)
        {
            _rule.Carga_ControlCargaInsertar(entidad, ref auditoria);
        }
        public void Ejecutar_Query(string _Query, ref enAuditoria auditoria)
        {
            _rule.Ejecutar_Query(_Query, ref auditoria);
        }
        public void Carga_Validar(long ID_CONTROL_CARGA, long ID_TABLA, ref enAuditoria auditoria)
        {
            _rule.Carga_Validar(ID_CONTROL_CARGA, ID_TABLA, ref auditoria);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

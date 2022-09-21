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
    public class SerieRepositorio : IDisposable
    {

        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neSerie _rule = null;

        public SerieRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neSerie(_objCoConexionDb);
        }

        public List<enSerie> Serie_Listar(enSerie entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Serie_Listar(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new List<enSerie>();
            }
        }
        public enSerie Serie_ListarUno(enSerie entidad, ref enAuditoria auditoria)
        {
            try
            {
                return _rule.Serie_ListarUno(entidad, ref auditoria);
            }
            catch (Exception ex)
            {
                auditoria.Error(ex);
                return new enSerie();
            }
        }

        public void Serie_Insertar(enSerie objenSerie, ref enAuditoria auditoria)
        {
            _rule.Serie_Insertar(objenSerie, ref auditoria);
        }
        public void Serie_Actualizar(enSerie objenSerie, ref enAuditoria auditoria)
        {
            _rule.Serie_Actualizar(objenSerie, ref auditoria);
        }
        public void Serie_Estado(enSerie objenSerie, ref enAuditoria auditoria)
        {
            _rule.Serie_Estado(objenSerie, ref auditoria);
        }
        public void Serie_Eliminar(enSerie objenSerie, ref enAuditoria auditoria)
        {
            _rule.Serie_Eliminar(objenSerie, ref auditoria);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion
{
    public class DocumentoRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neDocumento _rule = null;
        public DocumentoRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neDocumento(_objCoConexionDb);
        }
        public List<enDocumentoTemporal> DocumentoTemporal_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _rule.DocumentoTemporal_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

        public List<enDocumento> Documento_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _rule.Documento_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

        public List<enDocumento_Proceso> DocumentoProceso_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {
            return _rule.DocumentoProceso_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }

        public HashSet<enDocumento> Documento_Exportar( string @WHERE, ref enAuditoria auditoria)
        {
            return _rule.Documento_Exportar(@WHERE, ref auditoria);
        }


        public enDocumento Documento_ListarUno(enDocumento entidad, ref enAuditoria auditoria)
        {
            return _rule.Documento_ListarUno(entidad, ref auditoria);
        }

        public List<enDocumento_Obs> DocumentoObservado_Listar(enDocumento_Obs entidad, ref enAuditoria auditoria)
        {
            return _rule.DocumentoObservado_Listar(entidad, ref auditoria);
        }
        public void Documento_Grabar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_Grabar(entidad, ref auditoria);
        }

        public void Documento_AsignacionInsertar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_AsignacionInsertar(entidad, ref auditoria);
        }
        public void Documento_AsignacionActualizar(enDocumento entidad, ref enAuditoria auditoria)
        {
            _rule.Documento_AsignacionActualizar(entidad, ref auditoria);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

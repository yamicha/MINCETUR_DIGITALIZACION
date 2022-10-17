using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Models;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
namespace NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class neMicroforma : neBase
    {
        DaMicroforma _objDa = null;
        public neMicroforma(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaMicroforma(objCoConexionDb);
        }
        public List<enMicroforma> Microforma_Paginado(string ORDEN_COLUMNA, string ORDEN, int FILAS, int PAGINA, string @WHERE, ref enAuditoria auditoria)
        {

            return _objDa.Microforma_Paginado(ORDEN_COLUMNA, ORDEN, FILAS, PAGINA, @WHERE, ref auditoria);
        }
        public List<enMicroforma> Microforma_Listar(enMicroforma entidad, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_Listar(entidad, ref auditoria);
        }
        public List<enMicroforma> Microforma_ListarControl(enMicroforma entidad, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_ListarControl(entidad, ref auditoria);
        }
        public List<enMicroformaProceso> Microforma_ListarProcesos(enMicroformaProceso entidad, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_ListarProcesos(entidad, ref auditoria);
        }
        public enMicroforma Microforma_ListarUno(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_ListarUno(ID_MICROFORMA, ref auditoria);
        }

        public List<enRevision> Revision_Listar(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _objDa.Revision_Listar(ID_MICROFORMA, ref auditoria);
        }

        public List<enMicroArchivo> MicroArchivo_Listar(long ID_MICROFORMA, int FlgEstado, ref enAuditoria auditoria)
        {
            return _objDa.MicroArchivo_Listar(ID_MICROFORMA, FlgEstado, ref auditoria);
        }

        public List<enLote> Microforma_LotesListar(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_LotesListar(ID_MICROFORMA, ref auditoria);
        }

        public void Microforma_Insertar(MicroModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_Insertar(entidad, ref auditoria);
        }

        public void Microforma_Evaluar(MicroEvaluarModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_Evaluar(entidad, ref auditoria);
        }
        public void Microforma_Reprocesar(MicroModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_Reprocesar(entidad, ref auditoria);
        }

        public void Microforma_MicroArchivo(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_MicroArchivo(entidad, ref auditoria);
        }

        public void Microforma_MicroArchivoEstado(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_MicroArchivoEstado(entidad, ref auditoria);
        }

        public void Microforma_RevisionPeriodica(RevsionPeriodicaModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_RevisionPeriodica(entidad, ref auditoria);
        }
        public void Microforma_Desarchivar(MicroArchivoModels entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_Desarchivar(entidad, ref auditoria);
        }

        public void Microforma_RevisionReprocesar(MicroModel entidad, ref enAuditoria auditoria)
        {
            _objDa.Microforma_RevisionReprocesar(entidad, ref auditoria);
        }




    }
}

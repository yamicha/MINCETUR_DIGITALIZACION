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

        public List<enMicroforma> Microforma_Listar(enMicroforma entidad, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_Listar(entidad, ref auditoria);
        }
        public List<enMicroforma> Microforma_ListarControl(enMicroforma entidad, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_ListarControl(entidad, ref auditoria);
        }
        public enMicroforma Microforma_ListarUno(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _objDa.Microforma_ListarUno(ID_MICROFORMA, ref auditoria);
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


    }
}

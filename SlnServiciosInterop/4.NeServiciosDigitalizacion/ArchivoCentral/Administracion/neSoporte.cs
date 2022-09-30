using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neSoporte : neBase
    {
        DaSoporte _objDa = null;
        public neSoporte(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaSoporte(objCoConexionDb);
        }
        public List<enSoporte> Soporte_Listar(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Soporte_Listar(objEnSubSerie, ref auditoria);
        }
        public enSoporte Soporte_ListarUno(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Soporte_ListarUno(objEnSubSerie, ref auditoria);
        }
        public void Soporte_Insertar(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Soporte_Insertar(objEnSubSerie, ref auditoria);
        }
        public void Soporte_Actualizar(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Soporte_Actualizar(objEnSubSerie, ref auditoria);
        }
        public void Soporte_Estado(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Soporte_Estado(objEnSubSerie, ref auditoria);
        }

        public void Soporte_Eliminar(enSoporte objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Soporte_Eliminar(objEnSubSerie, ref auditoria);
        }

    }
}

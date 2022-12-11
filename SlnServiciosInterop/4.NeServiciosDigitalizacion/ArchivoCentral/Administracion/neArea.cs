using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neArea : neBase
    {
        DaArea _objDa = null;
        public neArea(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaArea(objCoConexionDb);
        }
        public List<enArea> Area_Listar(enArea entidad, ref enAuditoria auditoria)
        {
            return this._objDa.Area_Listar(entidad, ref auditoria);
        }

        public enArea Area_ListarUno(enArea entidad, ref enAuditoria auditoria)
        {
            return this._objDa.Area_ListarUno(entidad, ref auditoria);
        }
        public void Area_Insertar(enArea entidad, ref enAuditoria auditoria)
        {
            this._objDa.Area_Insertar(entidad, ref auditoria);
        }
        public void Area_Actualizar(enArea entidad, ref enAuditoria auditoria)
        {
            this._objDa.Area_Actualizar(entidad, ref auditoria);
        }
        public void Area_Estado(enArea entidad, ref enAuditoria auditoria)
        {
            this._objDa.Area_Estado(entidad, ref auditoria);
        }

        public void Area_Eliminar(enArea entidad, ref enAuditoria auditoria)
        {
            this._objDa.Area_Eliminar(entidad, ref auditoria);
        }

    }
}

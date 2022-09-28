using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;


namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neObservacion : neBase
    {
        DaObservacion _objDa = null;
        public neObservacion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaObservacion(objCoConexionDb);
        }
        public List<enObservacion> Observacion_Listar(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Observacion_Listar(objEnSubSerie, ref auditoria);
        }
        public enObservacion Observacion_ListarUno(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Observacion_ListarUno(objEnSubSerie, ref auditoria);
        }
        public void Observacion_Insertar(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Observacion_Insertar(objEnSubSerie, ref auditoria);
        }
        public void Observacion_Actualizar(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Observacion_Actualizar(objEnSubSerie, ref auditoria);
        }
        public void Observacion_Estado(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Observacion_Estado(objEnSubSerie, ref auditoria);
        }

        public void Observacion_Eliminar(enObservacion objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Observacion_Eliminar(objEnSubSerie, ref auditoria);
        }
    }
}

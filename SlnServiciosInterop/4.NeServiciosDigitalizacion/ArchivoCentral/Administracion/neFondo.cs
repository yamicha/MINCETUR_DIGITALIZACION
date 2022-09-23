using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neFondo : neBase
    {
        DaFondo _objDa = null;
        public neFondo(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaFondo(objCoConexionDb);
        }
        public List<enFondo> Fondo_Listar(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Fondo_Listar(objEnSubSerie, ref auditoria);
        }
        public enFondo Fondo_ListarUno(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Fondo_ListarUno(objEnSubSerie, ref auditoria);
        }
        public void Fondo_Insertar(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Fondo_Insertar(objEnSubSerie, ref auditoria);
        }
        public void Fondo_Actualizar(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Fondo_Actualizar(objEnSubSerie, ref auditoria);
        }
        public void Fondo_Estado(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Fondo_Estado(objEnSubSerie, ref auditoria);
        }

        public void Fondo_Eliminar(enFondo objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Fondo_Eliminar(objEnSubSerie, ref auditoria);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral;
using EnServiciosDigitalizacion;
using DaServiciosDigitalizacion.Archivo_Central;

namespace NeServiciosDigitalizacion.ArchivoCentral
{
    public class neSeccion : neBase
    {
        DaSeccion _objDa = null;
        public neSeccion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaSeccion(objCoConexionDb);
        }
        public List<enSeccion> Seccion_Listar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            return this._objDa.Seccion_Listar(objEnSeccion, ref auditoria);
        }
        public enSeccion Seccion_ListarUno(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            return this._objDa.Seccion_ListarUno(objEnSeccion, ref auditoria);
        }
        public void Seccion_Insertar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            this._objDa.Seccion_Insertar(objEnSeccion, ref auditoria);
        }
        public void Seccion_Actualizar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            this._objDa.Seccion_Actualizar(objEnSeccion, ref auditoria);
        }
        public void Seccion_Estado(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            this._objDa.Seccion_Estado(objEnSeccion, ref auditoria);
        }

        public void Seccion_Eliminar(enSeccion objEnSeccion, ref enAuditoria auditoria)
        {
            this._objDa.Seccion_Eliminar(objEnSeccion, ref auditoria);
        }


    }
}

using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion.Vistas;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neSerie : neBase
    {
        DaSerie _objDa = null;
        public neSerie(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaSerie(objCoConexionDb);
        }
        public List<Vserie> Serie_Listar(Vserie objEnSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Serie_Listar(objEnSerie, ref auditoria);
        }
        public Vserie Serie_ListarUno(Vserie objEnSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Serie_ListarUno(objEnSerie, ref auditoria);
        }
        public void Serie_Insertar(enSerie objEnSerie, ref enAuditoria auditoria)
        {
            this._objDa.Serie_Insertar(objEnSerie, ref auditoria);
        }
        public void Serie_Actualizar(enSerie objEnSerie, ref enAuditoria auditoria)
        {
            this._objDa.Serie_Actualizar(objEnSerie, ref auditoria);
        }
        public void Serie_Estado(enSerie objEnSerie, ref enAuditoria auditoria)
        {
            this._objDa.Serie_Estado(objEnSerie, ref auditoria);
        }

        public void Serie_Eliminar(enSerie objEnSerie, ref enAuditoria auditoria)
        {
            this._objDa.Serie_Eliminar(objEnSerie, ref auditoria);
        }
    }
}

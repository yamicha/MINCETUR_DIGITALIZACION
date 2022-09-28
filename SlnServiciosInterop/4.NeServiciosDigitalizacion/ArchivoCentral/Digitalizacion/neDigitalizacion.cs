﻿using System.Collections.Generic;
using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion
{
    public class neDigitalizacion : neBase
    {
        DaDigitalizacion _objDa = null;
        public neDigitalizacion(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaDigitalizacion(objCoConexionDb);
        }

        public List<enLote> Lote_Listar(enLote entidad, ref enAuditoria auditoria)
        {
            return _objDa.Lote_Listar(entidad, ref auditoria);
        }

        public void Documento_Digitalizar(enDocumento_Asignado entidad, ref enAuditoria auditoria)
        {
            _objDa.Documento_Digitalizar(entidad, ref auditoria);
        }
        public List<enDocumento_Proceso> Documento_Proceso_Listar(enDocumento_Proceso entidad, ref enAuditoria auditoria)
        {
            return _objDa.Documento_Proceso_Listar(entidad, ref auditoria);
        }


    }
}

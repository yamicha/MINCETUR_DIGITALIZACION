using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Carga;
using EnServiciosDigitalizacion;
using DaServiciosDigitalizacion.Archivo_Central.Carga;
using System.Data;

namespace NeServiciosDigitalizacion.ArchivoCentral.Carga
{
    public class enCarga : neBase
    {
        DaCarga _objDa = null;
        public enCarga(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaCarga(objCoConexionDb);
        }

        public void Registrar_Carga(string COD_TABLA_TEMPORAL, DataTable dt, string[] col, ref enAuditoria auditoria)
        {
            this._objDa.Registrar_Carga(COD_TABLA_TEMPORAL, dt, col, ref auditoria);
        }
        public enTabla Carga_TablaListarUno(enTabla objtabla, ref enAuditoria auditoria)
        {
            return this._objDa.Carga_TablaListarUno(objtabla, ref auditoria);
        }
        public void Carga_ControlCargaInsertar(enControlCarga entidad, ref enAuditoria auditoria)
        {
            this._objDa.Carga_ControlCargaInsertar(entidad, ref auditoria);
        }
        public List<enCampo> Carga_CamposListar(enCampo objcampo, ref enAuditoria auditoria)
        {
            return this._objDa.Carga_CamposListar(objcampo, ref auditoria);
        }
        public void Carga_Validar(long ID_CONTROL_CARGA, long ID_TABLA, ref enAuditoria auditoria)
        {
            this._objDa.Carga_Validar(ID_CONTROL_CARGA, ID_TABLA, ref auditoria);
        }
        public void Ejecutar_Query(string _Query, ref enAuditoria auditoria)
        {
            this._objDa.Ejecutar_Query(_Query, ref auditoria);
        }

    }
}

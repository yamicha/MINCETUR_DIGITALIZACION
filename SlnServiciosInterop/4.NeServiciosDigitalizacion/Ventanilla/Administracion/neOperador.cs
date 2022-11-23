using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.Ventanilla.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Ventanilla.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.Ventanilla.Administracion
{
    public class neOperador : neBase
    {
        DaOperador _objDa = null;
        public neOperador(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaOperador(objCoConexionDb);
        }

        public List<enOperador> Operador_Listar(enOperador objEnSubSerie, ref enAuditoria auditoria)
        {
            return this._objDa.Operador_Listar(objEnSubSerie, ref auditoria);
        }

        public void Operador_Insertar(enOperador objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Operador_Insertar(objEnSubSerie, ref auditoria);
        }
        public void Operador_Estado(enOperador objEnSubSerie, ref enAuditoria auditoria)
        {
            this._objDa.Operador_Estado(objEnSubSerie, ref auditoria);
        }

    }
}

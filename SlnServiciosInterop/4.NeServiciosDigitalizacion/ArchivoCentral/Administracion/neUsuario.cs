using CoServiciosDigitalizacion;
using DaServiciosDigitalizacion.ArchivoCentral.Administracion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Administracion;
using System.Collections.Generic;

namespace NeServiciosDigitalizacion.ArchivoCentral.Administracion
{
    public class neUsuario : neBase
    {
        DaUsuario _objDa = null;
        public neUsuario(coConexionDb objCoConexionDb) : base(objCoConexionDb)
        {
            _objDa = new DaUsuario(objCoConexionDb);
        }

        public List<enUsuario> Usuario_Listar(ref enAuditoria auditoria)
        {
            return this._objDa.Usuario_Listar(ref auditoria);
        }

    }
}

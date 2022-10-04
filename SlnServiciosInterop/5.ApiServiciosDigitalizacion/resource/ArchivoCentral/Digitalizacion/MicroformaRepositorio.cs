using System;
using System.Collections.Generic;
using System.Data;
using CoServiciosDigitalizacion;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.ArchivoCentral.Digitalizacion;
using EnServiciosDigitalizacion.Models;
using NeServiciosDigitalizacion.ArchivoCentral.Digitalizacion;

namespace ApiServiciosDigitalizacion.resource.ArchivoCentral.Digitalizacion
{
    public class MicroformaRepositorio : IDisposable
    {
        private Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> _ConfigurationManager;
        private coConexionDb _objCoConexionDb;
        private neMicroforma _rule = null;
        public MicroformaRepositorio(Microsoft.Extensions.Options.IOptions<resource.clases.ConfigurationManager> ConfigurationManager)
        {
            this._ConfigurationManager = ConfigurationManager;
            this._objCoConexionDb = new coConexionDb()
            {
                ServerCnx = this._ConfigurationManager.Value.AppSettings.ServerCnx,
                UserCnx = this._ConfigurationManager.Value.AppSettings.UserCnx,
                PassCnx = this._ConfigurationManager.Value.AppSettings.PassCnx,
                TNS_ADMIN = this._ConfigurationManager.Value.ConnectionStrings.Tns_Admin
            };
            _rule = new neMicroforma(_objCoConexionDb);
        }

        public List<enMicroforma> Microforma_Listar(enMicroforma entidad, ref enAuditoria auditoria)
        {
            return _rule.Microforma_Listar(entidad, ref auditoria);
        }
        public List<enLote> Microforma_LotesListar(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _rule.Microforma_LotesListar(ID_MICROFORMA, ref auditoria);
        }
        public enMicroforma Microforma_ListarUno(long ID_MICROFORMA, ref enAuditoria auditoria)
        {
            return _rule.Microforma_ListarUno(ID_MICROFORMA, ref auditoria);
        }
        public void Microforma_Insertar(MicroformaModel entidad, ref enAuditoria auditoria)
        {
            _rule.Microforma_Insertar(entidad, ref auditoria);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

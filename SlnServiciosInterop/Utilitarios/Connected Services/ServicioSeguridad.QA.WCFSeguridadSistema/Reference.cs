﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicioSeguridad.QA.WCFSeguridadSistema
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="enTipoAcceso", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.EnSegur" +
        "idad")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso))]
    public partial class enTipoAcceso : object
    {
        
        private string DES_TIPOACCESOField;
        
        private System.DateTime FEC_CREAField;
        
        private System.DateTime FEC_MODIField;
        
        private int ID_TIPOACCESOField;
        
        private string OPRField;
        
        private int USU_CREAField;
        
        private int USU_MODIField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DES_TIPOACCESO
        {
            get
            {
                return this.DES_TIPOACCESOField;
            }
            set
            {
                this.DES_TIPOACCESOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FEC_CREA
        {
            get
            {
                return this.FEC_CREAField;
            }
            set
            {
                this.FEC_CREAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FEC_MODI
        {
            get
            {
                return this.FEC_MODIField;
            }
            set
            {
                this.FEC_MODIField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_TIPOACCESO
        {
            get
            {
                return this.ID_TIPOACCESOField;
            }
            set
            {
                this.ID_TIPOACCESOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OPR
        {
            get
            {
                return this.OPRField;
            }
            set
            {
                this.OPRField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int USU_CREA
        {
            get
            {
                return this.USU_CREAField;
            }
            set
            {
                this.USU_CREAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int USU_MODI
        {
            get
            {
                return this.USU_MODIField;
            }
            set
            {
                this.USU_MODIField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="enAcceso", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.EnSegur" +
        "idad")]
    public partial class enAcceso : ServicioSeguridad.QA.WCFSeguridadSistema.enTipoAcceso
    {
        
        private int CANTIDADField;
        
        private string COD_FUENTEField;
        
        private string DES_OBSField;
        
        private string DES_SISField;
        
        private string DES_URLField;
        
        private System.DateTime FEC_ACCESOField;
        
        private string FEC_INIField;
        
        private int FLG_MOVILField;
        
        private int ID_ACCESOField;
        
        private int ID_PERSONAField;
        
        private int ID_SISField;
        
        private string IP_ACCESOField;
        
        private int ORDENField;
        
        private ServicioSeguridad.QA.WCFSeguridadSistema.enGeoPlugin enGeoPluginField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CANTIDAD
        {
            get
            {
                return this.CANTIDADField;
            }
            set
            {
                this.CANTIDADField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string COD_FUENTE
        {
            get
            {
                return this.COD_FUENTEField;
            }
            set
            {
                this.COD_FUENTEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DES_OBS
        {
            get
            {
                return this.DES_OBSField;
            }
            set
            {
                this.DES_OBSField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DES_SIS
        {
            get
            {
                return this.DES_SISField;
            }
            set
            {
                this.DES_SISField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DES_URL
        {
            get
            {
                return this.DES_URLField;
            }
            set
            {
                this.DES_URLField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FEC_ACCESO
        {
            get
            {
                return this.FEC_ACCESOField;
            }
            set
            {
                this.FEC_ACCESOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FEC_INI
        {
            get
            {
                return this.FEC_INIField;
            }
            set
            {
                this.FEC_INIField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FLG_MOVIL
        {
            get
            {
                return this.FLG_MOVILField;
            }
            set
            {
                this.FLG_MOVILField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_ACCESO
        {
            get
            {
                return this.ID_ACCESOField;
            }
            set
            {
                this.ID_ACCESOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_PERSONA
        {
            get
            {
                return this.ID_PERSONAField;
            }
            set
            {
                this.ID_PERSONAField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_SIS
        {
            get
            {
                return this.ID_SISField;
            }
            set
            {
                this.ID_SISField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IP_ACCESO
        {
            get
            {
                return this.IP_ACCESOField;
            }
            set
            {
                this.IP_ACCESOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ORDEN
        {
            get
            {
                return this.ORDENField;
            }
            set
            {
                this.ORDENField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServicioSeguridad.QA.WCFSeguridadSistema.enGeoPlugin enGeoPlugin
        {
            get
            {
                return this.enGeoPluginField;
            }
            set
            {
                this.enGeoPluginField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="enGeoPlugin", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.EnSegur" +
        "idad")]
    public partial class enGeoPlugin : ServicioSeguridad.QA.WCFSeguridadSistema.coHBase
    {
        
        private string GEOPLUGIN_AREACODEField;
        
        private string GEOPLUGIN_CITYField;
        
        private string GEOPLUGIN_CONTINENTCODEField;
        
        private string GEOPLUGIN_COUNTRYCODEField;
        
        private string GEOPLUGIN_COUNTRYNAMEField;
        
        private string GEOPLUGIN_CURRENCYCODEField;
        
        private string GEOPLUGIN_DMACODEField;
        
        private decimal GEOPLUGIN_LATITUDEField;
        
        private decimal GEOPLUGIN_LONGITUDEField;
        
        private string GEOPLUGIN_REGIONField;
        
        private string GEOPLUGIN_REGIONCODEField;
        
        private string GEOPLUGIN_REGIONNAMEField;
        
        private string GEOPLUGIN_REQUESTField;
        
        private string GEOPLUGIN_STATUSField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_AREACODE
        {
            get
            {
                return this.GEOPLUGIN_AREACODEField;
            }
            set
            {
                this.GEOPLUGIN_AREACODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_CITY
        {
            get
            {
                return this.GEOPLUGIN_CITYField;
            }
            set
            {
                this.GEOPLUGIN_CITYField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_CONTINENTCODE
        {
            get
            {
                return this.GEOPLUGIN_CONTINENTCODEField;
            }
            set
            {
                this.GEOPLUGIN_CONTINENTCODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_COUNTRYCODE
        {
            get
            {
                return this.GEOPLUGIN_COUNTRYCODEField;
            }
            set
            {
                this.GEOPLUGIN_COUNTRYCODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_COUNTRYNAME
        {
            get
            {
                return this.GEOPLUGIN_COUNTRYNAMEField;
            }
            set
            {
                this.GEOPLUGIN_COUNTRYNAMEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_CURRENCYCODE
        {
            get
            {
                return this.GEOPLUGIN_CURRENCYCODEField;
            }
            set
            {
                this.GEOPLUGIN_CURRENCYCODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_DMACODE
        {
            get
            {
                return this.GEOPLUGIN_DMACODEField;
            }
            set
            {
                this.GEOPLUGIN_DMACODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal GEOPLUGIN_LATITUDE
        {
            get
            {
                return this.GEOPLUGIN_LATITUDEField;
            }
            set
            {
                this.GEOPLUGIN_LATITUDEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal GEOPLUGIN_LONGITUDE
        {
            get
            {
                return this.GEOPLUGIN_LONGITUDEField;
            }
            set
            {
                this.GEOPLUGIN_LONGITUDEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_REGION
        {
            get
            {
                return this.GEOPLUGIN_REGIONField;
            }
            set
            {
                this.GEOPLUGIN_REGIONField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_REGIONCODE
        {
            get
            {
                return this.GEOPLUGIN_REGIONCODEField;
            }
            set
            {
                this.GEOPLUGIN_REGIONCODEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_REGIONNAME
        {
            get
            {
                return this.GEOPLUGIN_REGIONNAMEField;
            }
            set
            {
                this.GEOPLUGIN_REGIONNAMEField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_REQUEST
        {
            get
            {
                return this.GEOPLUGIN_REQUESTField;
            }
            set
            {
                this.GEOPLUGIN_REQUESTField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GEOPLUGIN_STATUS
        {
            get
            {
                return this.GEOPLUGIN_STATUSField;
            }
            set
            {
                this.GEOPLUGIN_STATUSField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="coHBase", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.CoSegur" +
        "idad")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ServicioSeguridad.QA.WCFSeguridadSistema.enGeoPlugin))]
    public partial class coHBase : object
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="coResultadoDB", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.CoSegur" +
        "idad")]
    public partial class coResultadoDB : ServicioSeguridad.QA.WCFSeguridadSistema.coHBase
    {
        
        private string DES_ERRORField;
        
        private string ID_ERRORField;
        
        private int ID_TIPOField;
        
        private int VALORField;
        
        private int VALOR1Field;
        
        private int VALOR10Field;
        
        private int VALOR2Field;
        
        private int VALOR3Field;
        
        private int VALOR4Field;
        
        private int VALOR5Field;
        
        private int VALOR6Field;
        
        private int VALOR7Field;
        
        private int VALOR8Field;
        
        private int VALOR9Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DES_ERROR
        {
            get
            {
                return this.DES_ERRORField;
            }
            set
            {
                this.DES_ERRORField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ID_ERROR
        {
            get
            {
                return this.ID_ERRORField;
            }
            set
            {
                this.ID_ERRORField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ID_TIPO
        {
            get
            {
                return this.ID_TIPOField;
            }
            set
            {
                this.ID_TIPOField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR
        {
            get
            {
                return this.VALORField;
            }
            set
            {
                this.VALORField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR1
        {
            get
            {
                return this.VALOR1Field;
            }
            set
            {
                this.VALOR1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR10
        {
            get
            {
                return this.VALOR10Field;
            }
            set
            {
                this.VALOR10Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR2
        {
            get
            {
                return this.VALOR2Field;
            }
            set
            {
                this.VALOR2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR3
        {
            get
            {
                return this.VALOR3Field;
            }
            set
            {
                this.VALOR3Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR4
        {
            get
            {
                return this.VALOR4Field;
            }
            set
            {
                this.VALOR4Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR5
        {
            get
            {
                return this.VALOR5Field;
            }
            set
            {
                this.VALOR5Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR6
        {
            get
            {
                return this.VALOR6Field;
            }
            set
            {
                this.VALOR6Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR7
        {
            get
            {
                return this.VALOR7Field;
            }
            set
            {
                this.VALOR7Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR8
        {
            get
            {
                return this.VALOR8Field;
            }
            set
            {
                this.VALOR8Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int VALOR9
        {
            get
            {
                return this.VALOR9Field;
            }
            set
            {
                this.VALOR9Field = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioSeguridad.QA.WCFSeguridadSistema.IWCFSeguridadSistema")]
    public interface IWCFSeguridadSistema
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadSistema/listarAccesosPorDia", ReplyAction="http://tempuri.org/IWCFSeguridadSistema/listarAccesosPorDiaResponse")]
        System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso[]> listarAccesosPorDiaAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadSistema/enviarAcceso", ReplyAction="http://tempuri.org/IWCFSeguridadSistema/enviarAccesoResponse")]
        System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB> enviarAccesoAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadSistema/enviarAccesoUlt", ReplyAction="http://tempuri.org/IWCFSeguridadSistema/enviarAccesoUltResponse")]
        System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB> enviarAccesoUltAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IWCFSeguridadSistemaChannel : ServicioSeguridad.QA.WCFSeguridadSistema.IWCFSeguridadSistema, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class WCFSeguridadSistemaClient : System.ServiceModel.ClientBase<ServicioSeguridad.QA.WCFSeguridadSistema.IWCFSeguridadSistema>, ServicioSeguridad.QA.WCFSeguridadSistema.IWCFSeguridadSistema
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WCFSeguridadSistemaClient() : 
                base(WCFSeguridadSistemaClient.GetDefaultBinding(), WCFSeguridadSistemaClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IWCFSeguridadSistema.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadSistemaClient(EndpointConfiguration endpointConfiguration) : 
                base(WCFSeguridadSistemaClient.GetBindingForEndpoint(endpointConfiguration), WCFSeguridadSistemaClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadSistemaClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WCFSeguridadSistemaClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadSistemaClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WCFSeguridadSistemaClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadSistemaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso[]> listarAccesosPorDiaAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso)
        {
            return base.Channel.listarAccesosPorDiaAsync(objEnAcceso);
        }
        
        public System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB> enviarAccesoAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso)
        {
            return base.Channel.enviarAccesoAsync(objEnAcceso);
        }
        
        public System.Threading.Tasks.Task<ServicioSeguridad.QA.WCFSeguridadSistema.coResultadoDB> enviarAccesoUltAsync(ServicioSeguridad.QA.WCFSeguridadSistema.enAcceso objEnAcceso)
        {
            return base.Channel.enviarAccesoUltAsync(objEnAcceso);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadSistema))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadSistema))
            {
                return new System.ServiceModel.EndpointAddress("http://svcqa.mincetur.gob.pe/servicioSeguridad/WCFSeguridadSistema.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WCFSeguridadSistemaClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadSistema);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WCFSeguridadSistemaClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadSistema);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IWCFSeguridadSistema,
        }
    }
}

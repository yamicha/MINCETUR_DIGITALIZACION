﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference2
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DocCmsSubir", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.GeneralesUtil.Ser" +
        "vicioWebDocCms.Models")]
    public partial class DocCmsSubir : object
    {
        
        private int IdDocCmsField;
        
        private int IdSisField;
        
        private string DesNomAbrField;
        
        private string DesRutaField;
        
        private byte[] ArchivoField;
        
        private string CodPinField;
        
        private int FlgPinField;
        
        private string CodCmsField;
        
        private int FlgCmsField;
        
        private int IdDocField;
        
        private int FlgDocField;
        
        private int IdUsuField;
        
        private string DatoField;
        
        private string IpAccesoField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdDocCms
        {
            get
            {
                return this.IdDocCmsField;
            }
            set
            {
                this.IdDocCmsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdSis
        {
            get
            {
                return this.IdSisField;
            }
            set
            {
                this.IdSisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string DesNomAbr
        {
            get
            {
                return this.DesNomAbrField;
            }
            set
            {
                this.DesNomAbrField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string DesRuta
        {
            get
            {
                return this.DesRutaField;
            }
            set
            {
                this.DesRutaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public byte[] Archivo
        {
            get
            {
                return this.ArchivoField;
            }
            set
            {
                this.ArchivoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string CodPin
        {
            get
            {
                return this.CodPinField;
            }
            set
            {
                this.CodPinField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int FlgPin
        {
            get
            {
                return this.FlgPinField;
            }
            set
            {
                this.FlgPinField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string CodCms
        {
            get
            {
                return this.CodCmsField;
            }
            set
            {
                this.CodCmsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public int FlgCms
        {
            get
            {
                return this.FlgCmsField;
            }
            set
            {
                this.FlgCmsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int IdDoc
        {
            get
            {
                return this.IdDocField;
            }
            set
            {
                this.IdDocField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public int FlgDoc
        {
            get
            {
                return this.FlgDocField;
            }
            set
            {
                this.FlgDocField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public int IdUsu
        {
            get
            {
                return this.IdUsuField;
            }
            set
            {
                this.IdUsuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public string Dato
        {
            get
            {
                return this.DatoField;
            }
            set
            {
                this.DatoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=13)]
        public string IpAcceso
        {
            get
            {
                return this.IpAccesoField;
            }
            set
            {
                this.IpAccesoField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Resultado", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.GeneralesUtil.Ser" +
        "vicioWebDocCms.Models")]
    public partial class Resultado : object
    {
        
        private int IdTipoField;
        
        private string DesErrorField;
        
        private string ValorField;
        
        private string Valor1Field;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int IdTipo
        {
            get
            {
                return this.IdTipoField;
            }
            set
            {
                this.IdTipoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string DesError
        {
            get
            {
                return this.DesErrorField;
            }
            set
            {
                this.DesErrorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Valor
        {
            get
            {
                return this.ValorField;
            }
            set
            {
                this.ValorField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string Valor1
        {
            get
            {
                return this.Valor1Field;
            }
            set
            {
                this.Valor1Field = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IWCFGeneralesDocCmsRegistro")]
    public interface IWCFGeneralesDocCmsRegistro
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFGeneralesDocCmsRegistro/insertar", ReplyAction="http://tempuri.org/IWCFGeneralesDocCmsRegistro/insertarResponse")]
        ServiceReference2.Resultado insertar(ServiceReference2.DocCmsSubir model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFGeneralesDocCmsRegistro/insertar", ReplyAction="http://tempuri.org/IWCFGeneralesDocCmsRegistro/insertarResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Resultado> insertarAsync(ServiceReference2.DocCmsSubir model);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IWCFGeneralesDocCmsRegistroChannel : ServiceReference2.IWCFGeneralesDocCmsRegistro, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class WCFGeneralesDocCmsRegistroClient : System.ServiceModel.ClientBase<ServiceReference2.IWCFGeneralesDocCmsRegistro>, ServiceReference2.IWCFGeneralesDocCmsRegistro
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WCFGeneralesDocCmsRegistroClient() : 
                base(WCFGeneralesDocCmsRegistroClient.GetDefaultBinding(), WCFGeneralesDocCmsRegistroClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IWCFGeneralesDocCmsRegistro.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFGeneralesDocCmsRegistroClient(EndpointConfiguration endpointConfiguration) : 
                base(WCFGeneralesDocCmsRegistroClient.GetBindingForEndpoint(endpointConfiguration), WCFGeneralesDocCmsRegistroClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFGeneralesDocCmsRegistroClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WCFGeneralesDocCmsRegistroClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFGeneralesDocCmsRegistroClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WCFGeneralesDocCmsRegistroClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFGeneralesDocCmsRegistroClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public ServiceReference2.Resultado insertar(ServiceReference2.DocCmsSubir model)
        {
            return base.Channel.insertar(model);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Resultado> insertarAsync(ServiceReference2.DocCmsSubir model)
        {
            return base.Channel.insertarAsync(model);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFGeneralesDocCmsRegistro))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFGeneralesDocCmsRegistro))
            {
                return new System.ServiceModel.EndpointAddress("http://svcdesa.mincetur.gob.pe:8080/servicioGenerales/docCms/Services/WCFGenerale" +
                        "sDocCmsRegistro.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WCFGeneralesDocCmsRegistroClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IWCFGeneralesDocCmsRegistro);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WCFGeneralesDocCmsRegistroClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IWCFGeneralesDocCmsRegistro);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IWCFGeneralesDocCmsRegistro,
        }
    }
}

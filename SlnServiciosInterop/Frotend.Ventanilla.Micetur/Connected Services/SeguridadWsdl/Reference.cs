﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeguridadWsdl
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DatosUsuSisRolEstorg", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.Servici" +
        "oWeb.Models")]
    public partial class DatosUsuSisRolEstorg : object
    {
        
        private int IdUsuField;
        
        private int IdSisField;
        
        private string IdRolField;
        
        private int IdEntField;
        
        private int IdSubField;
        
        private string IdSubOfiField;
        
        private string DatoField;
        
        private int FlgEstField;
        
        private string OprField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string IdRol
        {
            get
            {
                return this.IdRolField;
            }
            set
            {
                this.IdRolField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public int IdEnt
        {
            get
            {
                return this.IdEntField;
            }
            set
            {
                this.IdEntField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int IdSub
        {
            get
            {
                return this.IdSubField;
            }
            set
            {
                this.IdSubField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public string IdSubOfi
        {
            get
            {
                return this.IdSubOfiField;
            }
            set
            {
                this.IdSubOfiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int FlgEst
        {
            get
            {
                return this.FlgEstField;
            }
            set
            {
                this.FlgEstField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public string Opr
        {
            get
            {
                return this.OprField;
            }
            set
            {
                this.OprField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Resultado", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.Servici" +
        "oWeb.Models")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(SeguridadWsdl.ResultadoUsuSisRolEstorg))]
    public partial class Resultado : object
    {
        
        private int IdTipoField;
        
        private string DesErrorField;
        
        private string ValorField;
        
        private string Valor1Field;
        
        private string Valor2Field;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string Valor2
        {
            get
            {
                return this.Valor2Field;
            }
            set
            {
                this.Valor2Field = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultadoUsuSisRolEstorg", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.Servici" +
        "oWeb.Models")]
    public partial class ResultadoUsuSisRolEstorg : SeguridadWsdl.Resultado
    {
        
        private SeguridadWsdl.UsuSisRolEntEstorg[] lstUsuSisRolEntEstorgField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SeguridadWsdl.UsuSisRolEntEstorg[] lstUsuSisRolEntEstorg
        {
            get
            {
                return this.lstUsuSisRolEntEstorgField;
            }
            set
            {
                this.lstUsuSisRolEntEstorgField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuSisRolEntEstorg", Namespace="http://schemas.datacontract.org/2004/07/Mincetur.Administracion.Seguridad.Servici" +
        "oWeb.Models")]
    public partial class UsuSisRolEntEstorg : object
    {
        
        private int IdUsuSisRolEntField;
        
        private int IdEntField;
        
        private string DesEntField;
        
        private int IdUsuField;
        
        private string NomUsuField;
        
        private string NombresField;
        
        private string ApePaterField;
        
        private string ApeMaterField;
        
        private string CorreoField;
        
        private string CodLogField;
        
        private int IdSisField;
        
        private string DesSisField;
        
        private string IdRolField;
        
        private string DesRolField;
        
        private string CodEstField;
        
        private int IdSubField;
        
        private string IdSubOfiField;
        
        private string IdOfiConcatField;
        
        private string DesSubOfiField;
        
        private string AbrSubOfiField;
        
        private string FlgEstField;
        
        private string EstadoField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuSisRolEnt
        {
            get
            {
                return this.IdUsuSisRolEntField;
            }
            set
            {
                this.IdUsuSisRolEntField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int IdEnt
        {
            get
            {
                return this.IdEntField;
            }
            set
            {
                this.IdEntField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string DesEnt
        {
            get
            {
                return this.DesEntField;
            }
            set
            {
                this.DesEntField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string NomUsu
        {
            get
            {
                return this.NomUsuField;
            }
            set
            {
                this.NomUsuField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string Nombres
        {
            get
            {
                return this.NombresField;
            }
            set
            {
                this.NombresField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string ApePater
        {
            get
            {
                return this.ApePaterField;
            }
            set
            {
                this.ApePaterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string ApeMater
        {
            get
            {
                return this.ApeMaterField;
            }
            set
            {
                this.ApeMaterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public string Correo
        {
            get
            {
                return this.CorreoField;
            }
            set
            {
                this.CorreoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public string CodLog
        {
            get
            {
                return this.CodLogField;
            }
            set
            {
                this.CodLogField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=10)]
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=11)]
        public string DesSis
        {
            get
            {
                return this.DesSisField;
            }
            set
            {
                this.DesSisField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=12)]
        public string IdRol
        {
            get
            {
                return this.IdRolField;
            }
            set
            {
                this.IdRolField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=13)]
        public string DesRol
        {
            get
            {
                return this.DesRolField;
            }
            set
            {
                this.DesRolField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=14)]
        public string CodEst
        {
            get
            {
                return this.CodEstField;
            }
            set
            {
                this.CodEstField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=15)]
        public int IdSub
        {
            get
            {
                return this.IdSubField;
            }
            set
            {
                this.IdSubField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=16)]
        public string IdSubOfi
        {
            get
            {
                return this.IdSubOfiField;
            }
            set
            {
                this.IdSubOfiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=17)]
        public string IdOfiConcat
        {
            get
            {
                return this.IdOfiConcatField;
            }
            set
            {
                this.IdOfiConcatField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=18)]
        public string DesSubOfi
        {
            get
            {
                return this.DesSubOfiField;
            }
            set
            {
                this.DesSubOfiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=19)]
        public string AbrSubOfi
        {
            get
            {
                return this.AbrSubOfiField;
            }
            set
            {
                this.AbrSubOfiField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=20)]
        public string FlgEst
        {
            get
            {
                return this.FlgEstField;
            }
            set
            {
                this.FlgEstField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=21)]
        public string Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                this.EstadoField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SeguridadWsdl.IWCFSeguridadUsuSisRolEntEstorg")]
    public interface IWCFSeguridadUsuSisRolEntEstorg
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadUsuSisRolEntEstorg/listarUsuSisRolEntEstorg", ReplyAction="http://tempuri.org/IWCFSeguridadUsuSisRolEntEstorg/listarUsuSisRolEntEstorgRespon" +
            "se")]
        SeguridadWsdl.ResultadoUsuSisRolEstorg listarUsuSisRolEntEstorg(SeguridadWsdl.DatosUsuSisRolEstorg datos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadUsuSisRolEntEstorg/listarUsuSisRolEntEstorg", ReplyAction="http://tempuri.org/IWCFSeguridadUsuSisRolEntEstorg/listarUsuSisRolEntEstorgRespon" +
            "se")]
        System.Threading.Tasks.Task<SeguridadWsdl.ResultadoUsuSisRolEstorg> listarUsuSisRolEntEstorgAsync(SeguridadWsdl.DatosUsuSisRolEstorg datos);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IWCFSeguridadUsuSisRolEntEstorgChannel : SeguridadWsdl.IWCFSeguridadUsuSisRolEntEstorg, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class WCFSeguridadUsuSisRolEntEstorgClient : System.ServiceModel.ClientBase<SeguridadWsdl.IWCFSeguridadUsuSisRolEntEstorg>, SeguridadWsdl.IWCFSeguridadUsuSisRolEntEstorg
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WCFSeguridadUsuSisRolEntEstorgClient() : 
                base(WCFSeguridadUsuSisRolEntEstorgClient.GetDefaultBinding(), WCFSeguridadUsuSisRolEntEstorgClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadUsuSisRolEntEstorgClient(EndpointConfiguration endpointConfiguration) : 
                base(WCFSeguridadUsuSisRolEntEstorgClient.GetBindingForEndpoint(endpointConfiguration), WCFSeguridadUsuSisRolEntEstorgClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadUsuSisRolEntEstorgClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WCFSeguridadUsuSisRolEntEstorgClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadUsuSisRolEntEstorgClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WCFSeguridadUsuSisRolEntEstorgClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadUsuSisRolEntEstorgClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public SeguridadWsdl.ResultadoUsuSisRolEstorg listarUsuSisRolEntEstorg(SeguridadWsdl.DatosUsuSisRolEstorg datos)
        {
            return base.Channel.listarUsuSisRolEntEstorg(datos);
        }
        
        public System.Threading.Tasks.Task<SeguridadWsdl.ResultadoUsuSisRolEstorg> listarUsuSisRolEntEstorgAsync(SeguridadWsdl.DatosUsuSisRolEstorg datos)
        {
            return base.Channel.listarUsuSisRolEntEstorgAsync(datos);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg))
            {
                return new System.ServiceModel.EndpointAddress("http://svcqa.mincetur.gob.pe/servicioSeguridad/Services/WCFSeguridadUsuSisRolEntE" +
                        "storg.svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WCFSeguridadUsuSisRolEntEstorgClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WCFSeguridadUsuSisRolEntEstorgClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IWCFSeguridadUsuSisRolEntEstorg,
        }
    }
}

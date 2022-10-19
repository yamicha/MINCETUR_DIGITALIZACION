﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IWCFSeguridadEncripDesencrip")]
    public interface IWCFSeguridadEncripDesencrip
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/encriptarAES", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/encriptarAESResponse")]
        string encriptarAES(string plainText, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/encriptarAES", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/encriptarAESResponse")]
        System.Threading.Tasks.Task<string> encriptarAESAsync(string plainText, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/desencriptarAES", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/desencriptarAESResponse")]
        string desencriptarAES(string encryptText, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/desencriptarAES", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/desencriptarAESResponse")]
        System.Threading.Tasks.Task<string> desencriptarAESAsync(string encryptText, string clave);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/traeLlave", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/traeLlaveResponse")]
        string traeLlave();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSeguridadEncripDesencrip/traeLlave", ReplyAction="http://tempuri.org/IWCFSeguridadEncripDesencrip/traeLlaveResponse")]
        System.Threading.Tasks.Task<string> traeLlaveAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IWCFSeguridadEncripDesencripChannel : ServiceReference1.IWCFSeguridadEncripDesencrip, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class WCFSeguridadEncripDesencripClient : System.ServiceModel.ClientBase<ServiceReference1.IWCFSeguridadEncripDesencrip>, ServiceReference1.IWCFSeguridadEncripDesencrip
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WCFSeguridadEncripDesencripClient() : 
                base(WCFSeguridadEncripDesencripClient.GetDefaultBinding(), WCFSeguridadEncripDesencripClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IWCFSeguridadEncripDesencrip.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadEncripDesencripClient(EndpointConfiguration endpointConfiguration) : 
                base(WCFSeguridadEncripDesencripClient.GetBindingForEndpoint(endpointConfiguration), WCFSeguridadEncripDesencripClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadEncripDesencripClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WCFSeguridadEncripDesencripClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadEncripDesencripClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WCFSeguridadEncripDesencripClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WCFSeguridadEncripDesencripClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string encriptarAES(string plainText, string clave)
        {
            return base.Channel.encriptarAES(plainText, clave);
        }
        
        public System.Threading.Tasks.Task<string> encriptarAESAsync(string plainText, string clave)
        {
            return base.Channel.encriptarAESAsync(plainText, clave);
        }
        
        public string desencriptarAES(string encryptText, string clave)
        {
            return base.Channel.desencriptarAES(encryptText, clave);
        }
        
        public System.Threading.Tasks.Task<string> desencriptarAESAsync(string encryptText, string clave)
        {
            return base.Channel.desencriptarAESAsync(encryptText, clave);
        }
        
        public string traeLlave()
        {
            return base.Channel.traeLlave();
        }
        
        public System.Threading.Tasks.Task<string> traeLlaveAsync()
        {
            return base.Channel.traeLlaveAsync();
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadEncripDesencrip))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IWCFSeguridadEncripDesencrip))
            {
                return new System.ServiceModel.EndpointAddress("http://svcdesa.mincetur.gob.pe:8080/servicioSeguridad/WCFSeguridadEncripDesencrip" +
                        ".svc");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WCFSeguridadEncripDesencripClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadEncripDesencrip);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WCFSeguridadEncripDesencripClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IWCFSeguridadEncripDesencrip);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IWCFSeguridadEncripDesencrip,
        }
    }
}

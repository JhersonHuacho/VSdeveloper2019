﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Service.WCFAppTest.MantenimientoServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Artist", Namespace="http://schemas.datacontract.org/2004/07/App.Entities.Base")]
    [System.SerializableAttribute()]
    public partial class Artist : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ArtistIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ArtistId {
            get {
                return this.ArtistIdField;
            }
            set {
                if ((this.ArtistIdField.Equals(value) != true)) {
                    this.ArtistIdField = value;
                    this.RaisePropertyChanged("ArtistId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MantenimientoServices.IMantenimientoServices")]
    public interface IMantenimientoServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMantenimientoServices/GetArtistAll", ReplyAction="http://tempuri.org/IMantenimientoServices/GetArtistAllResponse")]
        System.Collections.Generic.List<App.Service.WCFAppTest.MantenimientoServices.Artist> GetArtistAll(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMantenimientoServices/GetArtistAll", ReplyAction="http://tempuri.org/IMantenimientoServices/GetArtistAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<App.Service.WCFAppTest.MantenimientoServices.Artist>> GetArtistAllAsync(string nombre);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMantenimientoServicesChannel : App.Service.WCFAppTest.MantenimientoServices.IMantenimientoServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MantenimientoServicesClient : System.ServiceModel.ClientBase<App.Service.WCFAppTest.MantenimientoServices.IMantenimientoServices>, App.Service.WCFAppTest.MantenimientoServices.IMantenimientoServices {
        
        public MantenimientoServicesClient() {
        }
        
        public MantenimientoServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MantenimientoServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MantenimientoServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MantenimientoServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<App.Service.WCFAppTest.MantenimientoServices.Artist> GetArtistAll(string nombre) {
            return base.Channel.GetArtistAll(nombre);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<App.Service.WCFAppTest.MantenimientoServices.Artist>> GetArtistAllAsync(string nombre) {
            return base.Channel.GetArtistAllAsync(nombre);
        }
    }
}

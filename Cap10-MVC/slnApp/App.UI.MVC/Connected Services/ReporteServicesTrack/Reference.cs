﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.UI.MVC.ReporteServicesTrack {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReporteServicesTrack.IReporteServices")]
    public interface IReporteServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReporteServices/GetTrackAll", ReplyAction="http://tempuri.org/IReporteServices/GetTrackAllResponse")]
        System.Collections.Generic.List<App.Entities.Queries.TrackAll> GetTrackAll(string trackName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReporteServices/GetTrackAll", ReplyAction="http://tempuri.org/IReporteServices/GetTrackAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<App.Entities.Queries.TrackAll>> GetTrackAllAsync(string trackName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IReporteServicesChannel : App.UI.MVC.ReporteServicesTrack.IReporteServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ReporteServicesClient : System.ServiceModel.ClientBase<App.UI.MVC.ReporteServicesTrack.IReporteServices>, App.UI.MVC.ReporteServicesTrack.IReporteServices {
        
        public ReporteServicesClient() {
        }
        
        public ReporteServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ReporteServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ReporteServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<App.Entities.Queries.TrackAll> GetTrackAll(string trackName) {
            return base.Channel.GetTrackAll(trackName);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<App.Entities.Queries.TrackAll>> GetTrackAllAsync(string trackName) {
            return base.Channel.GetTrackAllAsync(trackName);
        }
    }
}

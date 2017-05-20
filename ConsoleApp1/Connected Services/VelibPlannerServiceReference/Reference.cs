﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.VelibPlannerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Location", Namespace="http://schemas.datacontract.org/2004/07/velibPlanner")]
    [System.SerializableAttribute()]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double latitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double longitudeField;
        
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
        public double latitude {
            get {
                return this.latitudeField;
            }
            set {
                if ((this.latitudeField.Equals(value) != true)) {
                    this.latitudeField = value;
                    this.RaisePropertyChanged("latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude {
            get {
                return this.longitudeField;
            }
            set {
                if ((this.longitudeField.Equals(value) != true)) {
                    this.longitudeField = value;
                    this.RaisePropertyChanged("longitude");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Route", Namespace="http://schemas.datacontract.org/2004/07/velibPlanner")]
    [System.SerializableAttribute()]
    public partial class Route : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double durationField;
        
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
        public double duration {
            get {
                return this.durationField;
            }
            set {
                if ((this.durationField.Equals(value) != true)) {
                    this.durationField = value;
                    this.RaisePropertyChanged("duration");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibPlannerServiceReference.IVelibPlannerService")]
    public interface IVelibPlannerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibPlannerService/ComputeRoute", ReplyAction="http://tempuri.org/IVelibPlannerService/ComputeRouteResponse")]
        ConsoleApp1.VelibPlannerServiceReference.Route ComputeRoute(ConsoleApp1.VelibPlannerServiceReference.Location current, ConsoleApp1.VelibPlannerServiceReference.Location destination);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVelibPlannerService/ComputeRoute", ReplyAction="http://tempuri.org/IVelibPlannerService/ComputeRouteResponse")]
        System.Threading.Tasks.Task<ConsoleApp1.VelibPlannerServiceReference.Route> ComputeRouteAsync(ConsoleApp1.VelibPlannerServiceReference.Location current, ConsoleApp1.VelibPlannerServiceReference.Location destination);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVelibPlannerServiceChannel : ConsoleApp1.VelibPlannerServiceReference.IVelibPlannerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VelibPlannerServiceClient : System.ServiceModel.ClientBase<ConsoleApp1.VelibPlannerServiceReference.IVelibPlannerService>, ConsoleApp1.VelibPlannerServiceReference.IVelibPlannerService {
        
        public VelibPlannerServiceClient() {
        }
        
        public VelibPlannerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VelibPlannerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibPlannerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VelibPlannerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ConsoleApp1.VelibPlannerServiceReference.Route ComputeRoute(ConsoleApp1.VelibPlannerServiceReference.Location current, ConsoleApp1.VelibPlannerServiceReference.Location destination) {
            return base.Channel.ComputeRoute(current, destination);
        }
        
        public System.Threading.Tasks.Task<ConsoleApp1.VelibPlannerServiceReference.Route> ComputeRouteAsync(ConsoleApp1.VelibPlannerServiceReference.Location current, ConsoleApp1.VelibPlannerServiceReference.Location destination) {
            return base.Channel.ComputeRouteAsync(current, destination);
        }
    }
}
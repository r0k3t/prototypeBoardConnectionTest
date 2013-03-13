using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Microsoft.Ccr.Core;
using Microsoft.Dss.Core.Attributes;
using Microsoft.Dss.ServiceModel.Dssp;
using Microsoft.Dss.ServiceModel.DsspServiceBase;
using prototypeBoard = Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;
using Microsoft.Robotics.Services.Sample.Lego.Nxt.Commands;
using ccrwpf = Microsoft.Ccr.Adapters.Wpf;

namespace prototypeBoardConnectionTest
{
    [Contract(Contract.Identifier)]
    [DisplayName("prototypeBoardConnectionTest")]
    [Description("prototypeBoardConnectionTest service (no description provided)")]
    internal class prototypeBoardConnectionTestService : DsspServiceBase
    {
        [Partner("UserHiTechnicPrototypeBoard", Contract = prototypeBoard.Contract.Identifier, CreationPolicy = PartnerCreationPolicy.UseExistingOrCreate)] 
        private readonly prototypeBoard.PrototypeBoardOperations _prototypeBoardOperations = new prototypeBoard.PrototypeBoardOperations();

        [ServicePort("/prototypeBoardConnectionTest", AllowMultipleInstances = true)] 
        private prototypeBoardConnectionTestOperations _mainPort = new prototypeBoardConnectionTestOperations();

        [ServiceState] 
        private prototypeBoardConnectionTestState _state = new prototypeBoardConnectionTestState();

        ccrwpf.WpfServicePort _wpfServicePort;

        private ControlWindow _userInterface;

        public prototypeBoardConnectionTestService(DsspServiceCreationPort creationPort)
            : base(creationPort)
        {
        }

        protected override void Start()
        {
            // 
            // Add service specific initialization here
            // 
            SpawnIterator(Initialize);
            base.Start();
        }

        private IEnumerator<ITask> Initialize()
        {
            // create WPF adapter
            _wpfServicePort = ccrwpf.WpfAdapter.Create(TaskQueue);

            var runWindow = _wpfServicePort.RunWindow(() => new ControlWindow(new MainWindowViewModel(this)));
            yield return (Choice)runWindow;

            var exception = (Exception)runWindow;
            if (exception != null)
            {
                LogError(exception);
                StartFailed();
                yield break;
            }

            // need double cast because WPF adapter doesn't know about derived window types
            _userInterface = (Window)runWindow as ControlWindow;
        }

        internal void SetLedPortStatus(prototypeBoard.LedStatus ledStatus)
        {
            Arbiter.Choice(_prototypeBoardOperations.SetLed(new prototypeBoard.LedConfig
                {
                    Status = ledStatus
                }), x => { }, f => { });
        }

        internal void SendI2cRead()
        {

            prototypeBoard.ReadConfig request = new prototypeBoard.ReadConfig
            {
                ExpectedResponseSize = 15,
                TxData = new byte[] { 0x10, 0x41 }
            };
            Arbiter.Choice(_prototypeBoardOperations.ReadFromI2cAddress(request),
                r => 
                {
                    
                },
                f => { });
            
        }
    }
}
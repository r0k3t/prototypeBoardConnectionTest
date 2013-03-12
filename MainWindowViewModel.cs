using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;

namespace prototypeBoardConnectionTest
{
    internal class MainWindowViewModel: BaseViewModel
    {
        private LedStatus _selectedLedStatus;
        public RelayCommand SetButtonCommand { get; set; }
        public RelayCommand SendI2cCommand { get; set; }

        public LedStatus SelectedLedStatus
        {
            get { return _selectedLedStatus; }
            set
            {
                _selectedLedStatus = value;
                OnPropertyChanged("SelectedLedStatus");
                _service.SetLedPortStatus(value);
            }
        }

        private readonly prototypeBoardConnectionTestService _service;
        
        public MainWindowViewModel(prototypeBoardConnectionTestService service)
        {
            _service = service;
            SetButtonCommand = new RelayCommand(x => _service.SetLedPortStatus(LedStatus.Red));
            SendI2cCommand = new RelayCommand(x => _service.SendI2cRead());
        }
    }
}

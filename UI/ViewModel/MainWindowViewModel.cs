﻿using System.Collections.ObjectModel;
using Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;

namespace prototypeBoardConnectionTest.UI.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private int _deviceAddress;
        private int _readFromAddress;
        private int _expectedResponseSize;
        private int _theWidth;

        private string _deviceAddressHexString;
        private string _readFromAddressHexString;
        private string _expectedResponseSizeHexString;
        private ObservableCollection<byte> _returnedData;

        private LedStatus _selectedLedStatus;
        public RelayCommand SetButtonCommand { get; set; }
        public RelayCommand SendI2CCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }

        private readonly PrototypeBoardConnectionTestService _service;

        public MainWindowViewModel(PrototypeBoardConnectionTestService service)
        {
            _service = service;
            SetButtonCommand = new RelayCommand(x => _service.SetLedPortStatus(LedStatus.Red));
            SendI2CCommand = new RelayCommand(SendI2CRead);
            ExitCommand = new RelayCommand(x => _service.Exit());
            DeviceAddress = 0x10;
            ReadFromAddress = 0x41;
            ExpectedResponseSize = 12;
            TheWidth = 25;
        }

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

        public int DeviceAddress
        {
            get { return _deviceAddress; }
            set
            {
                _deviceAddress = value;
                DeviceAddressHexString = string.Format("0x{0}", _deviceAddress.ToString("X"));
                OnPropertyChanged("DeviceAddress");
            }
        }

        public int ReadFromAddress
        {
            get { return _readFromAddress; }
            set
            {
                _readFromAddress = value;
                ReadFromAddressHexString = string.Format("0x{0}", _readFromAddress.ToString("X"));
                OnPropertyChanged("ReadFromAddress");
            }
        }

        public int ExpectedResponseSize
        {
            get { return _expectedResponseSize; }
            set
            {
                _expectedResponseSize = value;
                ExpectedResponseSizeHexString = string.Format("0x{0}", _expectedResponseSize.ToString("X"));
                OnPropertyChanged("ExpectedResponseSize");
            }
        }

        public string DeviceAddressHexString
        {
            get { return _deviceAddressHexString; }
            set
            {
                _deviceAddressHexString = value;
                OnPropertyChanged("DeviceAddressHexString");
            }
        }

        public string ReadFromAddressHexString
        {
            get { return _readFromAddressHexString; }
            set
            {
                _readFromAddressHexString = value;
                OnPropertyChanged("ReadFromAddressHexString");
            }
        }

        public string ExpectedResponseSizeHexString
        {
            get { return _expectedResponseSizeHexString; }
            set
            {
                _expectedResponseSizeHexString = value;
                OnPropertyChanged("ExpectedResponseSizeHexString");
            }
        }

        public ObservableCollection<byte> ReturnedData
        {
            get { return _returnedData; }
            set
            {
                _returnedData = value;
                OnPropertyChanged("ReturnedData");
            }
        }

        public int TheWidth
        {
            get { return _theWidth; }
            set
            {
                _theWidth = value;
                OnPropertyChanged("TheWidth");
            }
        }

        public void SendI2CRead(object o)
        {
            _service.SendI2CRead((byte) _deviceAddress, (byte) _readFromAddress, _expectedResponseSize, SetReturnData);
        }

        public void SetReturnData(byte[] bytes)
        {
            ReturnedData = new ObservableCollection<byte>(bytes);
        }
    }
}
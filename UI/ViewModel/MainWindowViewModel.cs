using Microsoft.Robotics.Services.Sample.HiTechnic.PrototypeBoard.Proxy;

namespace prototypeBoardConnectionTest.UI.ViewModel
{
    internal class MainWindowViewModel: BaseViewModel
    {
        private string _deviceAddress;
        private string _readFromAddress;
        private int _expectedResponseSize;
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

        public string DeviceAddress
        {
            get { return _deviceAddress; }
            set
            {
                _deviceAddress = value;
                OnPropertyChanged("DeviceAddress");
            }
        }

        public string ReadFromAddress
        {
            get { return _readFromAddress; }
            set
            {
                _readFromAddress = value;
                OnPropertyChanged("ReadFromAddress");
            }
        }

        public int ExpectedResponseSize
        {
            get { return _expectedResponseSize; }
            set
            {
                _expectedResponseSize = value;
                OnPropertyChanged("ExpectedResponseSize");
            }
        }

        public void SendI2CRead(object o)
        {
            int deviceAddress;
            int.TryParse(_deviceAddress, out deviceAddress);

            int readFromAddress;
            int.TryParse(_readFromAddress, out readFromAddress);

            _service.SendI2CRead((byte)deviceAddress, (byte)readFromAddress, _expectedResponseSize);
        }
    }
}

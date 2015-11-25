using System;
using Windows.UI.Xaml;
using Emmellsoft.IoT.Rpi.SenseHat;
using GalaSoft.MvvmLight;

namespace SenseDash.Shared.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private DispatcherTimer _sensorUpdater;
        private ISenseHat _senseHat;
        private int _sensorUpdateCount;

        public MainPageViewModel(ISenseHat senseHat)
        {
            _senseHat = senseHat;

            _temperature = new TemperatureViewModel(senseHat);
            _humidity = new HumidityViewModel(senseHat);
            _pressure = new PressureViewModel(senseHat);
            _graph = new GraphViewModel(senseHat);

            _sensorUpdater = new DispatcherTimer();
            _sensorUpdater.Interval = TimeSpan.FromMilliseconds(100);
            _sensorUpdater.Tick += SensorUpdaterOnTick;
            _sensorUpdateCount = 0;
            _sensorUpdater.Start();

            
            senseHat.Display.Clear();
            senseHat.Display.Update();
        }

        private void SensorUpdaterOnTick(object sender, object o)
        {
            _sensorUpdateCount++;
            
            this.UpdateSensors();
            this.DisplayProgress();
        }

        private void DisplayProgress()
        {
           
        }

        private void UpdateSensors()
        {
            this.Temperature.Update();
            this.Humidity.Update();
            this.Pressure.Update();
            this.Graph.Update();
        }

        public string Title => "SenseDash";

        private TemperatureViewModel _temperature;
        public TemperatureViewModel Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                RaisePropertyChanged("Temperature");
            }
        }

        private HumidityViewModel _humidity;
        public HumidityViewModel Humidity
        {
            get { return _humidity; }
            set
            {
                _humidity = value;
                RaisePropertyChanged("Humidity");
            }
        }

        private PressureViewModel _pressure;
        public PressureViewModel Pressure
        {
            get { return _pressure; }
            set
            {
                _pressure = value;
                RaisePropertyChanged("Pressure");
            }
        }

        private GraphViewModel _graph;
        public GraphViewModel Graph
        {
            get { return _graph; }
            set
            {
                _graph = value;
                RaisePropertyChanged("Graph");
            }
        }
    }
}

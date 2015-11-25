using System;
using Emmellsoft.IoT.Rpi.SenseHat;
using GalaSoft.MvvmLight;

namespace SenseDash.Shared.ViewModel
{
    public class SensorViewModel : ViewModelBase
    {
        protected readonly ISenseHat _senseHat;

        public SensorViewModel(ISenseHat senseHat)
        {
            _senseHat = senseHat;
        }
        
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private double _value;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged("Value");
            }
        }

        private string _unit;
        public string Unit
        {
            get
            {
                return _unit;
            }
            set
            {
                _unit = value;
                RaisePropertyChanged("Unit");
            }
        }


        private double _minimum;
        public double Minimum
        {
            get
            {
                return _minimum;
            }
            set
            {
                _minimum = value;
                RaisePropertyChanged("Minimum");
            }
        }

        private double _maximum;
        public double Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                RaisePropertyChanged("Maximum");
            }
        }
    }
}

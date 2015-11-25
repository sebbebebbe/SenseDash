using System;
using System.Collections.ObjectModel;
using System.Linq;
using Emmellsoft.IoT.Rpi.SenseHat;
using GalaSoft.MvvmLight;

namespace SenseDash.Shared.ViewModel
{
    public class GraphViewModel : ViewModelBase
    {
        private readonly ISenseHat _senseHat;
        public GraphViewModel(ISenseHat senseHat)
        {
            _senseHat = senseHat;
            Temperature = new ObservableCollection<SensorReading>();
            Humidity = new ObservableCollection<SensorReading>();
            Pressure = new ObservableCollection<SensorReading>();
        }

        public void Update()
        {
            var temperatureReading = new SensorReading() { Value = _senseHat.Sensors.HumiditySensor.Readings.Temperature, Timestamp = _senseHat.Sensors.HumiditySensor.Readings.Timestamp };

            //var diff = temperatureReading.Timestamp.Subtract(Temperature.Min(x => x.Timestamp));

            var temperaturesToRemove = Temperature.Where(x => x.Timestamp < temperatureReading.Timestamp.AddSeconds(30));

            for (int i = 0; i < temperaturesToRemove.Count(); i++)
            {
                Temperature.Remove(temperaturesToRemove.ElementAt(i));
            }
           
            Temperature.Add(temperatureReading);
            

            var humidityReading = new SensorReading() { Value = _senseHat.Sensors.HumiditySensor.Readings.Humidity, Timestamp = _senseHat.Sensors.HumiditySensor.Readings.Timestamp };
            Humidity.Add(humidityReading);

            var pressureReading = new SensorReading() { Value = _senseHat.Sensors.PressureSensor.Readings.Pressure, Timestamp = _senseHat.Sensors.PressureSensor.Readings.Timestamp };
            Pressure.Add(pressureReading);
        }

        public ObservableCollection<SensorReading> Temperature { get; set; }

        public ObservableCollection<SensorReading> Humidity { get; set; }

        public ObservableCollection<SensorReading> Pressure { get; set; }

        public DateTime GraphMinimum { get; set; }

        public DateTime GraphMaximum { get; set; }

        public int GraphInterval { get; set; }
    }

    public class SensorReading
    {
   
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
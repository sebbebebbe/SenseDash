using Emmellsoft.IoT.Rpi.SenseHat;

namespace SenseDash.Shared.ViewModel
{
    public class TemperatureViewModel : SensorViewModel
    {
        public TemperatureViewModel(ISenseHat senseHat) : base(senseHat)
        {
            this.Title = "Temperature";
            this.Unit = "C";
            this.Minimum = -10;
            this.Maximum = 100;
        }

        public void Update()
        {
            _senseHat.Sensors.HumiditySensor.Update();

            if (_senseHat.Sensors.Temperature != null)
            {   
                Value = _senseHat.Sensors.Temperature.Value;
            }
        }
    }
}
